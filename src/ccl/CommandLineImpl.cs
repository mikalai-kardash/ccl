using System;
using ccl.Framework.Commands;
using ccl.Framework.Factory;
using ccl.Framework.Registration;
using ccl.Framework.Registration.Tree;
using ccl.Framework.Runner;
using ccl.Framework.Search;

namespace ccl
{
    public class CommandLineImpl
    {
        private readonly Element _tree = new Root();
        private readonly ICommandFactory _factory;
        private readonly ICommandRunner _runner;
        private readonly ICommandSearch _search;

        public CommandLineImpl(ICommandFactory factory, ICommandRunner runner, ICommandSearch search)
        {
            _factory = factory;
            _runner = runner;
            _search = search;
        }

        public void Register(Type type, params string[] path)
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
                    node.AddNode(part);
                }
                node = node[part];
            }

            node.AddCommand(type);
        }

        public void Register<T>(string[] path) where T : ICommand
        {
            Register(typeof (T), path);
        }

        public void Run(string[] args)
        {
            var context = _search.Search(_tree, args);

            foreach (var result in context)
            {
                var command = _factory.CreateCommand(result);
                _runner.Run(command);
            }
        }
    }
}