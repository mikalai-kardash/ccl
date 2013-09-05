using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ccl.Framework.Registration.Tree
{
    public class Command : Launchable
    {
        private readonly IDictionary<string, PropertyInfo> _aliases = new Dictionary<string, PropertyInfo>();

        public Command(Type type) : base(type.FullName)
        {
            Type = type;
        }

        public Type Type { get; private set; }

        public override void Accept(IRegistrationTreeWalker walker)
        {
            walker.Visit(this);
        }

        public void AddParameterAlias(string alias, PropertyInfo property)
        {
            var key = alias.ToLower();
            
            if (_aliases.ContainsKey(key))
            {
                throw new DuplicateNameException(
                    "The '{0}' alias is already associated with the property '{1}' of ");
            }

            _aliases.Add(key, property);
        }

        public bool HasAlias(string alias)
        {
            return _aliases.ContainsKey(alias.ToLower());
        }

        public PropertyInfo GetParameterForAlias(string alias)
        {
            return _aliases[alias.ToLower()];
        }
    }
}