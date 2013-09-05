using System;

namespace ccl.Framework.Factory.ValueConverters
{
    public class ConverterFactory
    {
        public static IValueConverter GetConverter(Type toType)
        {
            if (toType == typeof (int))
            {
                return new IntValueConverter();
            }
            if (toType == typeof (bool))
            {
                return new BooleanValueConverter();
            }
            if (toType == typeof (string) || toType == typeof (object))
            {
                return new DefaultValueConverter();
            }
            return new NullValueConverter();
        }
    }
}