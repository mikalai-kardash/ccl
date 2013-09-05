using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.tests.Commands
{
    [RegisterAs("install", "db")]
    public class InstallDatabase : CommandBase
    {
        public override void Execute()
        {
            IsExecuted = true;
        }

        public static bool IsExecuted { get; set; }
    }
}