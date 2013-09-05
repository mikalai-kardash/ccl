using System;
using System.Runtime.CompilerServices;

namespace ccl.Framework.Factory.ValueConverters
{
    public class NullValueConverter : IValueConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetValue(string value)
        {
            throw new NotSupportedException("Cannot convert value.");
        }
    }
}