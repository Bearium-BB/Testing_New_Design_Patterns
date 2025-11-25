using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectResolver
{
    private readonly ObjectResolver parent;


    public ObjectResolver() { }

    public ObjectResolver(ObjectResolver parent)
    {
        this.parent = parent;
    }

    //This dictionary binds a type and its object data together.
    //It is a dictionary so we can store both the type of the object and the object itself, which we can later use to determine what it is.
    public readonly Dictionary<Type, Registration> instancePerTypeMap = new Dictionary<Type, Registration>();


    //Lets us add stuff to the dictionary
    public void RegisterInstance<T>(object instance,Lifetime lifetime)
    {
        var type = instance.GetType();
        Registration registration = new Registration(lifetime, type, instance);
        instancePerTypeMap.TryAdd(typeof(T), registration);
    }

    public void RegisterInstance(Type serviceType, object instance, Lifetime lifetime)
    {
        var registration = new Registration(lifetime, instance.GetType(), instance);
        instancePerTypeMap[serviceType] = registration;
    }

    //This is an old feature that used the object resolver without any dependency injection,
    //but I like to keep it around because it is still useful to have.
    public T Resolve<T>()
    {
        Type targetType = typeof(T);

        if (instancePerTypeMap.TryGetValue(targetType, out Registration directReg))
            return (T)directReg.instance;

        foreach (var kvp in instancePerTypeMap)
        {
            var registeredType = kvp.Key;

            if (targetType.IsAssignableFrom(registeredType))
                return (T)kvp.Value.instance;
        }

        if (parent != null)
            return parent.Resolve<T>();

        // 4. Nothing found
        throw new Exception($"Cannot resolve type {targetType}");
    }


    //Essentially, this works by checking all the fields of a class and examining their flags to determine whether they are public, non-public,
    //or already instantiated. If any of those conditions are true, the field is stored. We then iterate through this list and check whether each field has the Injection attribute.
    //If it does, we use reflection to access the field and assign it the object from our dictionary based on its type.
    //This is how we set data using types.The dictionary stores different types and their corresponding objects,
    //and when a field has the Injection attribute, it knows to pull the correct object from the resolver. This means there is no code directly wired inside the scene or elsewhere.
    //If you see the Injection keyword, it means that field is connected to the Object Resolver.

    //Fields are variables inside your class
    //Flags are things like public and private
    //Attributes are the things that hard  brackets [Inject]

    public void InjectInto(object target)
    {
        var fields = target.GetType()
            .GetFields(BindingFlags.NonPublic |
                       BindingFlags.Public |
                       BindingFlags.Instance);

        foreach (var field in fields)
        {
            if (!Attribute.IsDefined(field, typeof(InjectAttribute)))
                continue;

            var fieldType = field.FieldType;

            if (instancePerTypeMap.TryGetValue(fieldType, out Registration reg))
            {
                field.SetValue(target, reg.instance);
                continue;
            }

            foreach (var kvp in instancePerTypeMap)
            {
                var registeredType = kvp.Key;

                if (fieldType.IsAssignableFrom(registeredType))
                {
                    field.SetValue(target, kvp.Value.instance);
                }
            }

            bool injected = false;

            foreach (var kvp in instancePerTypeMap)
            {
                if (fieldType.IsAssignableFrom(kvp.Key))
                {
                    field.SetValue(target, kvp.Value.instance);
                    injected = true;
                    break;
                }
            }

            if (parent != null)
            {
                parent.InjectInto(target);
                return;
            }


            if (!injected)
                throw new Exception($"Cannot inject field {field.Name} of type {fieldType}");
        }
    }

    public void CollectInjectables()
    {
        MonoBehaviour[] allMBs = GameObject.FindObjectsOfType<MonoBehaviour>();

        foreach (var mb in allMBs)
        {
            var type = mb.GetType();

            var attrs = (InjectableAttribute[])Attribute.GetCustomAttributes(type, typeof(InjectableAttribute));
            if (attrs.Length == 0)
                continue;

            foreach (var attr in attrs)
            {
                RegisterInstance(attr.type, mb, attr.lifetime);
            }
        }
    }

}

public class Registration
{
    public Lifetime lifetime;
    public Type implementationType;
    public object instance;

    public Registration(Lifetime lifetime, Type implementationType, object instance)
    {
        this.lifetime = lifetime;
        this.implementationType = implementationType;
        this.instance = instance;
    }
}


public enum Lifetime
{
    /// <summary>
    /// One instance for the entire application or game session.
    /// The resolver creates it once and always returns the same reference.
    /// Used for global systems such as audio, input, save system, or configuration data.
    /// </summary>
    Singleton,

    /// <summary>
    /// One instance for the current scene or gameplay context.
    /// When the scene changes, the instance is destroyed and recreated for the next scene.
    /// Used for scene specific services such as spawners, wave systems, or scene event hubs.
    /// </summary>
    SceneScoped,

    /// <summary>
    /// A new instance every time the resolver is asked for one.
    /// This is the lifetime used for objects created by factories or instantiation logic.
    /// Each request results in a fresh object with no shared state.
    /// Used for enemies, projectiles, items, or any entity level data.
    /// </summary>
    Transient,

    /// <summary>
    /// The resolver fetches the instance from an object pool instead of creating a new one.
    /// The pooled instance is reused and then returned to the pool when no longer needed.
    /// Used for high frequency entities such as bullets, effects, temporary UI elements, or particles.
    /// </summary>
    //Pooled
}
