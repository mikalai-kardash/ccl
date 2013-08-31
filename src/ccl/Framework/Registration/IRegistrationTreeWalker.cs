using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Registration
{
    public interface IRegistrationTreeWalker
    {
        void Visit(Command command);
        void Visit(Root root);
        void Visit(Node node);
    }
}