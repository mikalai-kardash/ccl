using ccl.Framework.Commands;
using ccl.Framework.Search;

namespace ccl.Framework.Factory
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(CommandSearchResult commandInfo);
    }
}