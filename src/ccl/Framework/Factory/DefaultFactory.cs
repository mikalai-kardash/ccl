using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ccl.Framework.Commands;
using ccl.Framework.Exceptions;
using ccl.Framework.Factory.ValueConverters;
using ccl.Framework.Search;

namespace ccl.Framework.Factory
{
    /// <summary>
    /// Creates instance of <see cref="ICommand"/> and applies all parameters to it.
    /// </summary>
    public class DefaultFactory : ICommandFactory, ISearchResultWalker
    {
        private ICommand _instance;

        public ICommand CreateCommand(CommandSearchResult commandInfo)
        {
            commandInfo.Accept(this);
            return _instance;
        }

        public void Visit(CommandNotFound notFound)
        {
            var message = String.Join(" ", notFound.Params);

            throw new CommandNotFoundException(message);
        }

        public void Visit(CommandFound found)
        {
            try
            {
                _instance = CreateInstance(found);

                var regexp = new Regex(@"[\/\-]{0,1}([\w]{1,}){1}[\=\:]{0,1}([\w]{1,}){0,1}", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var cmp = StringComparer.OrdinalIgnoreCase;

                foreach (var param in found.Params)
                {
                    if (!regexp.IsMatch(param))
                    {
                        continue;
                    }

                    var matches = regexp.Matches(param);
                    if (matches.Count != 1)
                    {
                        continue;
                    }

                    var groups = matches[0].Groups;
                    if (groups.Count != 3) // magic number, since we have two groups defined + 1 by default
                    {
                        continue;
                    }

                    const int parameter = 1;
                    const int value = 2;

                    var p = groups[parameter].Value;
                    var v = groups[value].Value;
                    var property = _instance.GetType()
                                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                            .SingleOrDefault(pr => cmp.Compare(pr.Name, p) == 0);
                    if (property != null)
                    {
                        ConverterFactory
                            .GetConverter(property.PropertyType)
                            .Set(_instance, property, v);
                    }
                }

            }
            catch (Exception exception)
            {
                throw new CommandNotCreatedException(found.CommandType.FullName, exception);
            }
        }

        private static ICommand CreateInstance(CommandFound found)
        {
            return (ICommand) Activator.CreateInstance(found.CommandType);
        }
    }
}