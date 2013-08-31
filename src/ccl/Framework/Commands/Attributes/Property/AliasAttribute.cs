using System;

namespace ccl.Framework.Commands.Attributes.Property
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class AliasAttribute : Attribute
    {
        public string Alias { get; private set; }

        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
}