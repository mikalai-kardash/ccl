using System;
using ccl.Framework.Configuration;
using ccl.Framework.Factory;
using ccl.Framework.Factory.ValueConverters;
using ccl.Framework.Registration;
using ccl.Framework.Search;

namespace ccl
{
    public class CommandLineConfiguration : ICommonConfiguration,
                                            ILaunchCoordination,
                                            IRegistryCoordination,
                                            IValueConverters
    {
        public CommandLineConfiguration()
        {
            Registry = new NullRegistryController();
            Launcher = new NullLauncher();
            Sherlock = new NullSearcher();
        }

        public ICommandSearch Sherlock { get; protected set; }
        public IRegistryController Registry { get; private set; }
        public ILauncher Launcher { get; private set; }

        public T Configure<T>() where T : class
        {
            if (!(this is T))
            {
                throw new NotSupportedException(
                    string.Format("The configuration of {0} is not supported.", typeof (T).Name));
            }
            return this as T;
        }

        public ICommonConfiguration SetSearcher(ICommandSearch searcher)
        {
            Sherlock = searcher;
            return this;
        }

        public ILaunchCoordination Add(ILauncher launcher)
        {
            launcher.Next = Launcher;
            Launcher = launcher;
            return this;
        }

        public IRegistryCoordination Add(IRegistryController controller)
        {
            controller.Next = Registry;
            Registry = controller;

            return this;
        }

        public IValueConverters Add(IValueConverter converter)
        {
            throw new System.NotImplementedException();
        }

        IValueConverters IValueConverters.Clear()
        {
            Launcher = new NullLauncher();
            return this;
        }

        IRegistryCoordination IRegistryCoordination.Clear()
        {
            Registry = new NullRegistryController();
            return this;
        }
    }
}