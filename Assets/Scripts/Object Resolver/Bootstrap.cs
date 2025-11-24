using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //This list is for people who need to provide references directly at the start.
    //Any object or MonoBehaviour you place here will be added and registered with the Object Resolver,
    //and can then be provided to any other scripts that need injection.
    [SerializeField] private List<Object> registeredObjects = new List<Object>();


    private ObjectResolver resolver;


    //This Awake function will take the list of starting scripts, add them to the Object Resolver, and then inject every MonoBehaviour in the scene that requires it.
    private void Awake()
    {
        resolver = new ObjectResolver();
        resolver.RegisterInstance(this);

        foreach (var obj in registeredObjects)
        {
            RegisterObject(obj);
        }

        var allBehaviours = FindObjectsOfType<MonoBehaviour>();

        foreach (var mb in allBehaviours)
            resolver.InjectInto(mb);
    }

    //This lets you inject new objects that are created at runtime, and then gather all of the MonoBehaviours inside that GameObject.
    //So this works best with a spawning script that manages all spawning/pooling system, rather than just instantiating random scripts.
    public void InjectIntoInstance(GameObject gameObject)
    {
        MonoBehaviour[] allBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>();

        foreach (var mb in allBehaviours)
            resolver.InjectInto(mb);
    }

    //Essentially takes in a game object and registers it to the object resolver.
    private void RegisterObject(Object obj)
    {
        if (obj == null)
            return;

        if (obj is GameObject go)
        {
            MonoBehaviour[] allBehaviours = go.GetComponentsInChildren<MonoBehaviour>();
            foreach (var mb in allBehaviours)
                resolver.RegisterInstance(mb);
        }
        else if (obj is MonoBehaviour mb)
        {
            resolver.RegisterInstance(mb);
        }
        else
        {
            resolver.RegisterInstance(obj);
        }
    }
}
