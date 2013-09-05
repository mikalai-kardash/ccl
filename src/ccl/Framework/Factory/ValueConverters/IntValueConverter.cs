using System;

namespace ccl.Framework.Factory.ValueConverters
{
    public class IntValueConverter : IValueConverter
    {
        public object GetValue(string value)
        {
            int parsed;
            if (int.TryParse(value, out parsed))
            {
                return parsed;
            }
            throw new ArgumentOutOfRangeException(
                "value",
                value,
                string.Format("Unable to convert '{0}' into '{1}'", value, typeof (int).FullName));
        }
    }
}