namespace ccl.Framework.Logging
{
    public interface IReporter
    {
        void Write(string message);
        void Write(string format, params object[] args);
    }
}