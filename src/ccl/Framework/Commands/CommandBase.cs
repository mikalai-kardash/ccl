using System;
using System.Diagnostics;
using ccl.Framework.Commands.Context;
using ccl.Framework.Exceptions;

namespace ccl.Framework.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected CommandBase()
        {
            Context = new NullContext();
        }

        private bool _isDebug;

        public ICommandContext Context { get; set; }

        public virtual void BeforeExecute()
        {
        }

        public abstract void Execute();

        public virtual void AfterExecute()
        {
        }

        public virtual void OnException(Exception excepion)
        {
            throw new CommandNotRunException(GetType().FullName, excepion);
        }

        public bool IsDebug
        {
            get { return _isDebug; }

            [DebuggerStepThrough]
            set
            {
                if (value)
                {
                    Debugger.Launch();
                }
                _isDebug = value;
            }
        }
    }
}