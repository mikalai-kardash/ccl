using System;

namespace ccl.Framework.Commands
{
    public interface ICommand
    {
        void BeforeExecute();
        void Execute();
        void AfterExecute();
        void OnException(Exception excepion);
    }

}