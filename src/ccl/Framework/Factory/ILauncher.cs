using System.Collections.Generic;
using ccl.Framework.Configuration;
using ccl.Framework.Registration.Tree;

namespace ccl.Framework.Factory
{
    public interface ILauncher : IChainable<ILauncher>, IEnumerable<ILauncher>
    {
        bool CanLaunch(Launchable command);
        void Launch(Launchable command, string[] args);
    }
}