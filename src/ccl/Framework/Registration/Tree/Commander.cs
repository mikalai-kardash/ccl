using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ccl.Framework.Registration.Tree
{
    public class Commander : Launchable
    {
        private readonly IDictionary<string, ParameterInfo> _aliases = new Dictionary<string, ParameterInfo>();

        public Commander(Type commander, MethodInfo command) : base(commander.FullName)
        {
            Type = commander;
            Method = command;
        }

        public Type Type { get; private set; }
        public MethodInfo Method { get; private set; }

        public override void Accept(IRegistrationTreeWalker walker)
        {
            walker.Visit(this);
        }

        public void AddParameterAlias(string alias, ParameterInfo parameter)
        {
            var key = alias.ToLower();

            if (_aliases.ContainsKey(key))
            {
                throw new DuplicateNameException(
                    string.Format(
                        "The '{0}' alias is already registered for the '{1}' parameter of the '{2}' method of the '{3}' commander.",
                        key,
                        parameter.Name,
                        Method.Name,
                        Name));
            }

            _aliases.Add(key, parameter);
        }

        public bool HasAlias(string alias)
        {
            return _aliases.ContainsKey(alias.ToLower());
        }

        public ParameterInfo GetAlias(string alias)
        {
            return _aliases[alias.ToLower()];
        }
    }
}