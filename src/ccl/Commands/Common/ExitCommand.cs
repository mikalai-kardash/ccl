using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.Commands.Common
{
    [RegisterAs("exit")]
    [RegisterAs("quit")]
    public class ExitCommand : CommandBase
    {
        public int ExitCode { get; set; }

        public override void Execute()
        {
            Environment.Exit(ExitCode);
        }
    }
}