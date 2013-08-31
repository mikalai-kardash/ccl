using ccl.Framework.Search;

namespace ccl.Framework.Registration.Tree
{
    public class Root : Element
    {
        public Root() : base(string.Empty)
        {
        }

        public override void Accept(IRegistrationTreeWalker walker)
        {
            walker.Visit(this);
        }
    }
}