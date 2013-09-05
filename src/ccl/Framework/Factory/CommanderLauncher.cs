using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ccl.Framework.Factory.ValueConverters;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Factory
{
    public class CommanderLauncher : ILauncher
    {
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
            return command is Commander;
        }

        public void Launch(Launchable command, string[] args)
        {
            var commander = (Commander) command;
            var instance = Activator.CreateInstance(commander.Type);

            var map = new Dictionary<string, int>();
            var prms = commander.Method.GetParameters().ToList();
            var data = new object[prms.Count];

            var idx = 0;
            foreach (var param in prms)
            {
                map.Add(param.Name, idx++);
            }

            var regexp = new Regex(ParameterPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var groupCollections = args
                .Where(p => regexp.IsMatch(p))
                .Select(p => regexp.Matches(p))
                .Where(m => m.Count == 1)
                .Where(m => m[0].Groups.Count == 3)
                .Select(m => m[0].Groups);

            var cmp = StringComparer.OrdinalIgnoreCase;
            foreach (var groups in groupCollections)
            {
                const int parameter = 1;
                const int value = 2;

                var p = groups[parameter].Value;
                var v = groups[value].Value;

                // todo
                if (commander.HasAlias(p))
                {
                    var param = commander.GetAlias(p);
                    var pidx = map[param.Name];
                    data[pidx] = ConverterFactory.GetConverter(param.ParameterType).GetValue(v);
                }
            }

            commander.Method.Invoke(instance, data);
        }

        private const string ParameterPattern = @"[\/\-]{0,1}([\w]{1,}){1}[\=\:]{0,1}([\w]{1,}){0,1}";
    }
}