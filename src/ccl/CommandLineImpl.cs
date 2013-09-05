using System;
using ccl.Framework.Commands;
using ccl.Framework.Exceptions;
using ccl.Framework.Registration;
using ccl.Framework.Registration.Tree;

namespace ccl
{
    public class CommandLineImpl : CommandLineConfiguration, ICommandLine
    {
        private readonly Element _tree = new Root();

        public void Register<T>(string[] path) where T : ICommand
        {
            Register(typeof (T), path);
        }

// ReSharper disable MethodOverloadWithOptionalParameter
        public void Register(Type type, params string[] path)
// ReSharper restore MethodOverloadWithOptionalParameter
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            if (path.Length == 0)
            {
                throw new ArgumentOutOfRangeException("path", "Length eq. to 0.");
            }

            var node = _tree;
            foreach (var part in path)
            {
                if (!node.Contains(part))
                {
                    node.Add(new Node(part));
                }
                node = node[part];
            }

            Register(type, node);
        }

        public void Register(Type type)
        {
            Register(type, _tree);
        }

        public void Run(string[] args)
        {
            var found = false;
            foreach (var brick in Sherlock.Search(_tree, args))
            {
                found = true;
                foreach (var catapult in Launcher)
                {
                    if (!catapult.CanLaunch(brick.Item1))
                    {
                        continue;
                    }
                    catapult.Launch(brick.Item1, brick.Item2);
                    break;
                }
            }
            if (!found)
            {
                throw new CommandNotFoundException(string.Join(" ", args));
            }
        }

        private void Register(Type type, Element root)
        {
            foreach (var r in Registry)
            {
                if (!r.CanRegister(type))
                {
                    continue;
                }
                r.Register(type, root);
                break;
            }
        }
    }
}