using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Class;

namespace ccl.tests.Commands
{
    [RegisterAs("cannot", "create")]
    public class CannotCreateCommand : CommandBase
    {
        public CannotCreateCommand()
        {
            throw new InvalidOperationException("Ha-ha-ha!");
        }

        public override void Execute()
        {
        }
    }
}