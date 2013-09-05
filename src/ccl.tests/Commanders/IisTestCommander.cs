using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;
using ccl.Framework.Commands.Attributes.Method;
using ArgumentAlias = ccl.Framework.Commands.Attributes.Argument.AliasAttribute;

namespace ccl.tests.Commanders
{
    [RegisterAs("iis")]
    public class IisTestCommander : ICommander
    {
        public static bool IsRestarted { get; set; }

        public static bool IsStarted { get; set; }

        [Command]
        public void Restart([ArgumentAlias("harsh")] bool force)
        {
            IsRestarted = true;
        }

        [Command]
        public void Start()
        {
            IsStarted = true;
        }
    }
}