using System;
using System.Collections;
using System.Collections.Generic;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Factory
{
    public class NullLauncher : ILauncher
    {
        public ILauncher Next { get; set; }

        public IEnumerator<ILauncher> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool CanLaunch(Launchable command)
        {
            return false;
        }

        public void Launch(Launchable command, string[] args)
        {
            throw new NotSupportedException("Cannot launch commands!");
        }
    }
}