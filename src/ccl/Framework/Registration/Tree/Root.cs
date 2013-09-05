using System.Collections.Generic;

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

        public override IEnumerator<Element> GetEnumerator()
        {
            yield break;
        }
    }
}