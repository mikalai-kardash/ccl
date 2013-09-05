using System;

namespace ccl.Framework.Commands.Attributes.Method
{
    /// <summary>
    /// Merker attribute used on Commander classes to identify.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CommandAttribute : Attribute
    {
    }
}