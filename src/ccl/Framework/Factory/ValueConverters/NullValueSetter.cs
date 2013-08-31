using System.Reflection;
using System.Runtime.CompilerServices;

namespace ccl.Framework.Factory.ValueConverters
{
    public class NullValueSetter : IValueSetter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Set(object instance, PropertyInfo property, string value)
        {
        }
    }
}