using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;
using ccl.Framework.Commands.Attributes.Property;

namespace ccl.tests.Commands
{
    [RegisterAs("run", "hidden")]
    public class CommandWithHiddenParameter : CommandBase
    {
        [Hidden]
        public string Param
        {
            get { return ParameterValue; }
            set { ParameterValue = value; }
        }

        public static string ParameterValue { get; set; }

        public override void Execute()
        {
        }
    }
}