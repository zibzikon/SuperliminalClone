using System;

namespace Code.Attributes.Injection
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ImplicitInjectableAttribute : Attribute
    {
    }
}