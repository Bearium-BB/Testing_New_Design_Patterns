
//This makes attribute tag injection
//[Inject]
using System;

[AttributeUsage(AttributeTargets.Field)]
public class InjectAttribute : Attribute
{
    public Type ResolveAs { get; }

    // optional constructor for convenience
    public InjectAttribute(Type resolveAs = null)
    {
        ResolveAs = resolveAs;
    }
}

