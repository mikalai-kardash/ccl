using System;

namespace ccl.Framework.Commands.Attributes.Argument
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true, Inherited = false)]
    public class AliasAttribute : Attribute
    {
        public string Alias { get; private set; }

        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
}