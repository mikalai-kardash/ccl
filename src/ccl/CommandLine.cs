using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ccl.Framework.Commands;
using ccl.Framework.Configuration;
using ccl.Framework.Factory;
using ccl.Framework.Registration;
using ccl.Framework.Search;

namespace ccl
{
    public class CommandLine
    {
        private static readonly CommandLineImpl cl;

        static CommandLine()
        {
            cl = new CommandLineImpl();

            cl.Configure<ICommonConfiguration>()
              .SetSearcher(new DefaultCommandSearch());

            cl.Configure<IRegistryCoordination>()
              .Add(new CommandRegistryController())
              .Add(new CommanderRegistryController());

            cl.Configure<ILaunchCoordination>()
              .Add(new CommandLauncher())
              .Add(new CommanderLauncher());

            RegisterAllCommands();
        }

        private static void RegisterAllCommands()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(GetAllTypes);
            foreach (var type in types)
            {
                var isCommandOrCommander = typeof (ICommand).IsAssignableFrom(type) ||
                                           typeof (ICommander).IsAssignableFrom(type);
                if (!isCommandOrCommander || type.IsAbstract)
                {
                    continue;
                }

                cl.Register(type);
            }
        }

        private static IEnumerable<Type> GetAllTypes(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null).ToList();
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