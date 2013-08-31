using System;
using ccl.Framework.Commands;

namespace ccl.Framework.Runner
{
    /// <summary>
    /// Command runner is responsible for executing the command and should be able to handle exceptions raising from commands.
    /// </summary>
    public interface ICommandRunner
    {
        void Run(ICommand command);
        void OnException(ICommand command, Exception exception);
        void BeforeCommandRun(ICommand command);
        void AfterCommandRun(ICommand command);
    }
}