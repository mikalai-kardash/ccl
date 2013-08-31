namespace ccl.Framework.Search
{
    public interface ISearchResultWalker
    {
        void Visit(CommandNotFound notFound);
        void Visit(CommandFound found);
    }
}