﻿using System;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes;
using ccl.Framework.Commands.Attributes.Class;

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