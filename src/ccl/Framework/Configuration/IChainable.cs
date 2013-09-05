namespace ccl.Framework.Configuration
{
    public interface IChainable<T>
    {
        T Next { get; set; }
    }
}