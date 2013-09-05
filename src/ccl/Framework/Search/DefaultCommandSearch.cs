using System;
using System.Collections.Generic;
using System.Linq;
using ccl.Framework.Registration;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Search
{
    public class DefaultCommandSearch : ICommandSearch
    {
        public IEnumerable<Tuple<Launchable, string[]>> Search(Element element, string[] args)
        {
            var current = element;
            int skip = 0;
            foreach (var part in args)
            {
                if (current.Contains(part))
                {
                    current = current[part];
                    skip++;
                }
                else
                {
                    break;
                }
            }

            var prms = args.Skip(skip).ToArray();
            foreach (var command in current.OfType<Launchable>())
            {
                yield return new Tuple<Launchable, string[]>(command, prms);
            }
        }
    }
}