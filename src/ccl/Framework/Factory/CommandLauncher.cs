using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using ccl.Framework.Commands;
using ccl.Framework.Commands.Attributes.Property;
using ccl.Framework.Exceptions;
using ccl.Framework.Factory.ValueConverters;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Factory
{
    public class CommandLauncher : ILauncher
    {
        private const string ParameterPattern = @"[\/\-]{0,1}([\w]{1,}){1}[\=\:]{0,1}([\w]{1,}){0,1}";

        public ILauncher Next { get; set; }

        public IEnumerator<ILauncher> GetEnumerator()
        {
            yield return this;
            foreach (var next in Next)
            {
                yield return next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool CanLaunch(Launchable command)
        {
            return command is Command;
        }

        public void Launch(Launchable command, string[] args)
        {
            if (!(command is Command))
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Launchable should be of type command, got '{0}' instead.", command.GetType()));
            }

            RunCommand(
                CreateCommand(args, command as Command));
        }

        private static ICommand CreateCommand(string[] args, Command c)
        {
            ICommand instance;
            try
            {
                instance = (ICommand) Activator.CreateInstance(c.Type);
                ApplyProperties(args, c, instance);
            }
            catch (Exception exception)
            {
                throw new CommandNotCreatedException(c.Type.FullName, exception);
            }
            return instance;
        }

        private static void RunCommand(ICommand instance)
        {
            var commandRun = false;
            try
            {
                instance.BeforeExecute();
                instance.Execute();
                commandRun = true;
                instance.AfterExecute();
            }
            catch (Exception exception)
            {
                instance.OnException(exception);
            }
            finally
            {
                if (!commandRun)
                {
                    instance.AfterExecute();
                }
            }
        }

        private static void ApplyProperties(string[] args, Command c, object instance)
        {
            var all = c.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var r = new HashSet<string>();
            foreach (var prop in all)
            {
                var required = prop.GetCustomAttribute(typeof (RequiredAttribute), false);
                if (required == null)
                {
                    continue;
                }

                r.Add(prop.Name);
            }

            var regexp = new Regex(ParameterPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var groupCollections = args
                .Where(p => regexp.IsMatch(p))
                .Select(p => regexp.Matches(p))
                .Where(m => m.Count == 1)
                .Where(m => m[0].Groups.Count == 3)
                .Select(m => m[0].Groups);

            foreach (var groups in groupCollections)
            {
                const int parameter = 1;
                const int value = 2;

                var p = groups[parameter].Value;
                var v = groups[value].Value;

                if (!c.HasAlias(p))
                {
                    continue;
                }

                var prop = c.GetParameterForAlias(p);
                prop.SetValue(
                    instance,
                    ConverterFactory.GetConverter(prop.PropertyType).GetValue(v));

                if (r.Contains(prop.Name))
                {
                    r.Remove(prop.Name);
                }
            }

            if (r.Count > 0)
            {
                throw new ArgumentException(
                    string.Format(
                        "Required arguments not supplied: {0}.",
                        string.Join(", ", r.ToArray())));
            }
        }
    }
}