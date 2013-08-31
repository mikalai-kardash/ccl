using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Registration
{
    public abstract class Element : IEnumerable<Element>
    {
        private readonly IList<Element> _list = new List<Element>();
        private readonly StringComparer _cmp;

        protected Element(string name)
        {
            _cmp = StringComparer.OrdinalIgnoreCase;
            Name = name;
        }

        public abstract void Accept(IRegistrationTreeWalker walker);

        public string Name { get; protected set; }

        public bool Contains(string node)
        {
            return _list.Any(e => _cmp.Compare(node, e.Name) == 0);
        }

        public void AddNode(string name)
        {
            _list.Add(new Node(name));
        }

        public Element this[string name]
        {
            get
            {
                if (_list.Count == 0)
                {
                    throw new ArgumentOutOfRangeException("name", "No elements.");
                }
                var element = _list.FirstOrDefault(e => _cmp.Compare(e.Name, name) == 0);
                if (_list == null)
                {
                    throw new InstanceNotFoundException("Element is not present in the list.");
                }
                return element;
            }
        }

        public void AddCommand(Type commandType)
        {
            var existing = _list
                .Where(e => e is Command)
                .OfType<Command>()
                .FirstOrDefault(c => c.Type == commandType);

            if (existing != null)
            {
                throw new NotSupportedException(
                    string.Format("Cannot add same command [{0}] using the same configuration.", commandType.FullName));
            }

            _list.Add(new Command(commandType));
        }

        public void Clear()
        {
            _list.Clear();
        }

        public IEnumerator<Element> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type GetCommand()
        {
            return _list
                .Where(e => e is Command)
                .OfType<Command>()
                .Single()
                .Type;
        }
    }
}