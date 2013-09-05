using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;
using ccl.Framework.Commands.Attributes.Property;

namespace ccl.tests.Commands
{
    [RegisterAs("command", "required")]
    public class CommandWithRequiredAttribute : CommandBase
    {
        [Required]
        public string Required { get; set; }

        public override void Execute()
        {
        }
    }
}