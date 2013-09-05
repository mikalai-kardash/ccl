using System;
using System.Collections;
using System.Collections.Generic;

namespace ccl.Framework.Registration
{
    public abstract class RegistryControllerBase : IRegistryController
    {
        public IRegistryController Next { get; set; }

        public IEnumerator<IRegistryController> GetEnumerator()
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

        public abstract bool CanRegister(Type type);
        public abstract void Register(Type type, Element registrationTreeRoot);
    }
}