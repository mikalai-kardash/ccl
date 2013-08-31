namespace ccl.Framework.Commands
{
    public abstract class CommandBase : ICommand
    {
        public abstract void Execute();

        public bool IsDebug { get; set; }
    }
}