using System;

namespace ccl.Framework.Commands.Attributes.Property
{
    /// <summary>
    /// Merker attribute used on Commander classes to identify.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
    }
}