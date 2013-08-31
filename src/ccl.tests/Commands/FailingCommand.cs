using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;

namespace ccl.tests.Commands
{
    [RegisterAs("throw", "exception")]
    public class FailingCommand : CommandBase
    {
        public override void Execute()
        {
            throw new InvalidOperationException("Ha-ha-ha!");
        }
    }
}