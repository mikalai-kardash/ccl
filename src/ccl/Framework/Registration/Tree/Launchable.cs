namespace ccl.Framework.Registration.Tree
{
    public abstract class Launchable : Element
    {
        protected Launchable(string name) : base(name)
        {
        }

        public abstract override void Accept(IRegistrationTreeWalker walker);
    }
}