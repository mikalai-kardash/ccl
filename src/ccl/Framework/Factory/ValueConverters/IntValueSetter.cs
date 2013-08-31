using System;
using System.Reflection;

namespace ccl.Framework.Factory.ValueConverters
{
    public class IntValueSetter : IValueSetter
    {
        public void Set(object instance, PropertyInfo property, string value)
        {
            if (Convert(instance, property, value))
            {
                return;
            }
            OnConvertionFailed(value, typeof (int));
        }

        private static bool Convert(object instance, PropertyInfo property, string value)
        {
            int parsed;
            if (int.TryParse(value, out parsed))
            {
                property.SetValue(instance, parsed);
                return true;
            }
            return false;
        }

        private static void OnConvertionFailed(string value, Type toType)
        {
            throw new ArgumentOutOfRangeException(
                "value",
                value,
                string.Format("Unable to convert '{0}' into '{1}'", value, toType.FullName));
        }
    }
}