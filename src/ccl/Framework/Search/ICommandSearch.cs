using System;
using System.Collections.Generic;
using ccl.Framework.Registration;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Search
{
    public interface ICommandSearch
    {
        IEnumerable<Tuple<Launchable, string[]>> Search(Element element, string[] args);
    }
}