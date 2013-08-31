using ccl.Framework.Search;

namespace ccl.Framework.Registration.Tree
{
    public class Node : Element
    {
        public Node(string name) : base(name)
        {
        }

        public override void Accept(IRegistrationTreeWalker walker)
        {
            walker.Visit(this);
        }
    }
}