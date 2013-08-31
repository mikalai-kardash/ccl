using System;

namespace ccl.Framework.Commands.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class HiddenAttribute : Attribute
    {
    }
}