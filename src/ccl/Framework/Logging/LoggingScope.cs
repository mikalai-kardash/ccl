namespace ccl.Framework.Logging
{
    public abstract class LoggingScope : ILoggingScope
    {
        private bool _disposed;

        public string ScopeName { get; private set; }

        protected LoggingScope(string name)
        {
            ScopeName = name;
            Init();
        }

        protected abstract void StartScope();

        protected abstract void EndScope();

        private void Init()
        {
            StartScope();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposing) return;
            if (_disposed) return;
            try
            {
                EndScope();
            }
            finally
            {
                _disposed = true;
            }
        }
    }
}