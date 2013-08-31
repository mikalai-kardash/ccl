using System;

namespace ccl.Framework.Logging
{
    public interface ILoggingScope : IDisposable
    {
        string ScopeName { get; }
    }
}