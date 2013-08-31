namespace ccl.Framework.Search
{
    public abstract class CommandSearchResult
    {
        public string[] Params { get; set; }
        public abstract void Accept(ISearchResultWalker walker);
    }
}