using System;
using System.Runtime.CompilerServices;
using ccl.Framework.Commands;
using ccl.Framework.Exceptions;

namespace ccl.Framework.Runner
{
    public class DefaultCommandRunner : ICommandRunner
    {
        public void Run(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            var commandRun = false;
            try
            {
                BeforeCommandRun(command);
                command.Execute();
                commandRun = true;
                AfterCommandRun(command);
            }
            catch (Exception ex)
            {
                OnException(command, ex);
            }
            finally
            {
                if (!commandRun)
                {
                    AfterCommandRun(command);
                }
            }
        }

        public virtual void OnException(ICommand command, Exception exception)
        {
            throw new CommandNotRunException(command.GetType().FullName, exception);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void BeforeCommandRun(ICommand command)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void AfterCommandRun(ICommand command)
        {
        }
    }
}