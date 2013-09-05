using System;

namespace ccl.Framework.Commands.Attributes.Class
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class RegisterAsAttribute : Attribute
    {
        public string[] Path { get; private set; }

        public RegisterAsAttribute(params string[] path)
        {
            Path = path;
        }
    }
}