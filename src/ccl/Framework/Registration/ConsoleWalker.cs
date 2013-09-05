using System;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Registration
{
    public class ConsoleWalker : IRegistrationTreeWalker
    {
        public void Visit(Command command)
        {
        }

        public void Visit(Commander command)
        {
        }

        public void Visit(Root root)
        {
            Console.WriteLine("/");
            foreach (var element in root)
            {
                element.Accept(this);
            }
        }

        public void Visit(Node node)
        {
            throw new System.NotImplementedException();
        }
    }
}