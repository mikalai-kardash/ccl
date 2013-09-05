using ccl.Framework.Search;

namespace ccl.Framework.Configuration
{
    public interface ICommonConfiguration
    {
        ICommonConfiguration SetSearcher(ICommandSearch searcher);
    }
}