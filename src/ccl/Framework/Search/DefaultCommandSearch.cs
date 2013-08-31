using System.Collections.Generic;
using System.Linq;
using ccl.Framework.Registration;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Search
{
    public class DefaultCommandSearch : ICommandSearch
    {
        public IEnumerable<CommandSearchResult> Search(Element element, string[] args)
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

            var found = false;
            var prms = args.Skip(skip).ToArray();
            foreach (var command in current.OfType<Command>())
            {
                found = true;
                yield return new CommandFound
                    {
                        CommandType = command.Type,
                        Params = prms
                    };
            }
            if (!found)
            {
                yield return new CommandNotFound { Params = args.ToArray() };
            }
        }
    }
}