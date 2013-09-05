using System;
using System.Linq;
using System.Reflection;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;
using ccl.Framework.Commands.Attributes.Property;
using ccl.Framework.Registration.Tree;
using AliasAttribute = ccl.Framework.Commands.Attributes.Argument.AliasAttribute;

namespace ccl.Framework.Registration
{
    public class CommandRegistryController : RegistryControllerBase
    {
        public override bool CanRegister(Type type)
        {
            if (typeof (ICommand).IsAssignableFrom(type))
            {
                return true;
            }
            return false;
        }

        public override void Register(Type type, Element registrationTreeRoot)
        {
            // register command into the path
            var registerAs = type.GetCustomAttributes(typeof (RegisterAsAttribute), false);
            var node = registrationTreeRoot;
            if (registerAs.Length != 0)
            {
                var path = ((RegisterAsAttribute) registerAs[0]).Path;
                foreach (var part in path)
                {
                    if (!node.Contains(part))
                    {
                        node.Add(new Node(part));
                    }
                    node = node[part];
                }
            }

            // make sure there are no other commands on the same path
            if (node.OfType<Command>().Any())
            {
                throw new NotSupportedException(
                    string.Format("Cannot add same command [{0}] using the same configuration.", type.FullName));
            }

            // create command object from type
            var command = new Command(type);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var hidden = prop.GetCustomAttribute(typeof (HiddenAttribute), false);
                if (hidden != null)
                {
                    continue;
                }

                command.AddParameterAlias(prop.Name, prop);
                var aliases = prop.GetCustomAttributes(typeof (AliasAttribute), false);
                foreach (AliasAttribute alias in aliases)
                {
                    command.AddParameterAlias(alias.Alias, prop);
                }
            }

            node.Add(command);
        }
    }
}