using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class InjectableAttribute : Attribute
{
    public Type type { get; }
    public Lifetime lifetime { get; }

    public InjectableAttribute(Type type,Lifetime lifetime)
    {
        this.type = type;
        this.lifetime = lifetime;
    }
}

