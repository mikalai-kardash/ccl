using System;
using System.Linq;
using System.Reflection;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;
using ccl.Framework.Factory;
using ccl.Framework.Runner;
using ccl.Framework.Search;

namespace ccl
{
    public class CommandLine
    {
        private static readonly CommandLineImpl cl;

        static CommandLine()
        {
            cl = new CommandLineImpl(
                new DefaultFactory(),
                new DefaultCommandRunner(),
                new DefaultCommandSearch());

            RegisterAllCommands();
        }

        private static void RegisterAllCommands()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
            foreach (var type in types)
            {
                if (!typeof(ICommand).IsAssignableFrom(type))
                {
                    continue;
                }

                var registrations = type.GetCustomAttributes(typeof (RegisterAsAttribute), false);
                if (registrations.Length <= 0)
                {
                    continue;
                }

                foreach (RegisterAsAttribute registration in registrations)
                {
                    cl.Register(type, registration.Path);
                }
            }
        }

        public static void Register<T>(params string[] args)
            where T : ICommand
        {
            cl.Register<T>(args);
        }

        public static void Run(params string[] args)
        {
            cl.Run(args);
        }
    }
}