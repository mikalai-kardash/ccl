using System;

namespace ccl.Framework.Search
{
    public class CommandFound : CommandSearchResult
    {
        public Type CommandType { get; set; }

        public override void Accept(ISearchResultWalker walker)
        {
            walker.Visit(this);
        }
    }
}