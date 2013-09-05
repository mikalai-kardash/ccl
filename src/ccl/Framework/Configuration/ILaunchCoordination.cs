using ccl.Framework.Factory;

namespace ccl.Framework.Configuration
{
    public interface ILaunchCoordination
    {
        ILaunchCoordination Add(ILauncher launcher);
    }
}