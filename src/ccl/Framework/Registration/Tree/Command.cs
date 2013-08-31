using System;
using ccl.Framework.Search;

namespace ccl.Framework.Registration.Tree
{
    public class Command : Element
    {
        public Command(Type type) : base(type.FullName)
        {
            Type = type;
        }

        public Type Type { get; private set; }

        public override void Accept(IRegistrationTreeWalker walker)
        {
            walker.Visit(this);
        }
    }
}