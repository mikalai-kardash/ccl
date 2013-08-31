using System.Collections.Generic;
using ccl.Framework.Registration;

namespace ccl.Framework.Search
{
    public interface ICommandSearch
    {
        IEnumerable<CommandSearchResult> Search(Element element, string[] args);
    }
}