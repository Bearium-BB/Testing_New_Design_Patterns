using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectResolver
{
    //This dictionary binds a type and its object data together.
    //It is a dictionary so we can store both the type of the object and the object itself, which we can later use to determine what it is.
    public readonly Dictionary<Type, object> instancePerTypeMap = new Dictionary<Type, object>();


    //Lets us add stuff to the dictionary
    public void RegisterInstance(object instance)
    {
        var type = instance.GetType();
        instancePerTypeMap[type] = instance;
    }

    //This is an old feature that used the object resolver without any dependency injection,
    //but I like to keep it around because it is still useful to have.
    public T Resolve<T>()
    {
        Type typeInstance = typeof(T);
        if (instancePerTypeMap.TryGetValue(typeInstance, out var instance))
        {
            return (T)instance;
        }
        return default;
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
            .GetFields(System.Reflection.BindingFlags.NonPublic |
                       System.Reflection.BindingFlags.Public |
                       System.Reflection.BindingFlags.Instance);

        foreach (var field in fields)
        {
            if (Attribute.IsDefined(field, typeof(InjectAttribute)))
            {
                if (instancePerTypeMap.TryGetValue(field.FieldType, out var instance))
                {
                    field.SetValue(target, instance);
                }
            }
        }
    }
}
