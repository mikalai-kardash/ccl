using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.tests.Commands
{
    [RegisterAs("with", "params")]
    public class CommandWithParameters : CommandBase
    {
        public string Param1
        {
            get { return Param1Value; }
            set { Param1Value = value; }
        }

        public int Param2
        {
            get { return Param2Value; }
            set { Param2Value = value; }
        }

        public bool Param3
        {
            get { return Param3Value; }
            set { Param3Value = value; }
        }

        public static string Param1Value { get; set; }
        public static int Param2Value { get; set; }
        public static bool Param3Value { get; set; }

        public override void Execute()
        {
        }
    }
}