using System;
using System.Collections;
using System.Collections.Generic;

namespace ccl.Framework.Registration
{
    public class NullRegistryController : IRegistryController
    {
        public IRegistryController Next { get; set; }

        public IEnumerator<IRegistryController> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool CanRegister(Type type)
        {
            return false;
        }

        public void Register(Type type, Element registrationTreeRoot)
        {
            throw new NotSupportedException("Cannot register anything.");
        }
    }
}