using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.Commands.Common
{
    [RegisterAs("help")]
    public class HelpCommand : CommandBase
    {
        public override void Execute()
        {
            // This is to print out help info on the commands registered
        }
    }
}