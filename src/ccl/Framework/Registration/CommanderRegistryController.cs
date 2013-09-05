using System;
using System.Reflection;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;
using ccl.Framework.Commands.Attributes.Method;
using ccl.Framework.Registration.Tree;
using ArgumentAlias = ccl.Framework.Commands.Attributes.Argument.AliasAttribute;

namespace ccl.Framework.Registration
{
    public class CommanderRegistryController : RegistryControllerBase
    {
        public override bool CanRegister(Type type)
        {
            return typeof (ICommander).IsAssignableFrom(type);
        }

        public override void Register(Type type, Element registrationTreeRoot)
        {
            var registerAs = type.GetCustomAttributes(typeof (RegisterAsAttribute), false);
            var node = registrationTreeRoot;
            if (registerAs.Length > 0)
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

            var commands = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var command in commands)
            {
                if (command.GetCustomAttribute(typeof (CommandAttribute), false) == null)
                {
                    continue;
                }

                if (node.Contains(command.Name))
                {
                    continue;
                }

                var commandNode = new Node(command.Name);
                node.Add(commandNode);

                var registration = new Commander(type, command);
                foreach (var parameter in command.GetParameters())
                {
                    registration.AddParameterAlias(parameter.Name, parameter);
                    var aliases = parameter.GetCustomAttributes(typeof (ArgumentAlias), false);
                    foreach (ArgumentAlias alias in aliases)
                    {
                        registration.AddParameterAlias(alias.Alias, parameter);
                    }
                }

                commandNode.Add(registration);
            }
        }
    }
}