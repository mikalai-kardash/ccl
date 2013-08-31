using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;

namespace ccl.tests.Commands
{
    [RegisterAs("cannot", "create")]
    public class CannotCreateCommand : ICommand
    {
        public CannotCreateCommand()
        {
            throw new InvalidOperationException("Ha-ha-ha!");
        }

        public void Execute()
        {
        }
    }
}