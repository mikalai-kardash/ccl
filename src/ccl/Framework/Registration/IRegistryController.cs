using System;
using System.Collections.Generic;
using ccl.Framework.Configuration;

namespace ccl.Framework.Registration
{
    public interface IRegistryController : IChainable<IRegistryController>, IEnumerable<IRegistryController>
    {
        bool CanRegister(Type type);
        void Register(Type type, Element registrationTreeRoot);
    }
}