using System;

namespace ccl.Framework.Factory.ValueConverters
{
    public class ConverterFactory
    {
        public static IValueSetter GetConverter(Type toType)
        {
            if (toType == typeof (int))
            {
                return new IntValueSetter();
            }
            if (toType == typeof (bool))
            {
                return new BooleanValueSetter();
            }
            if (toType == typeof (string) || toType == typeof (object))
            {
                return new DefaultValueSetter();
            }
            return new NullValueSetter();
        }
    }
}