namespace ccl.Framework.Search
{
    public class CommandNotFound : CommandSearchResult
    {
        public override void Accept(ISearchResultWalker walker)
        {
            walker.Visit(this);
        }
    }
}