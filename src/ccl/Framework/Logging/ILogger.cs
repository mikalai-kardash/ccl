using System;

namespace ccl.Framework.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Info(string messageFormat, params object[] args);
        void Info(Exception exception);

        void Warning(string message);
        void Warning(string messageFormat, params object[] args);
        void Warning(Exception exception);

        void Error(string message);
        void Error(string messageFormat, params object[] args);
        void Error(Exception exception);
    }
}