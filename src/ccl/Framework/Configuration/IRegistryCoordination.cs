using ccl.Framework.Registration;

namespace ccl.Framework.Configuration
{
    public interface IRegistryCoordination
    {
        IRegistryCoordination Add(IRegistryController controller);
        IRegistryCoordination Clear();
    }
}