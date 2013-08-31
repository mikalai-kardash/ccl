using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;

namespace ccl.tests.Commands
{
    [RegisterAs("install", "db")]
    public class InstallDatabase : ICommand
    {
        public void Execute()
        {
            IsExecuted = true;
        }

        public static bool IsExecuted { get; set; }
    }
}