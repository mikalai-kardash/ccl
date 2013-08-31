using System.Reflection;

namespace ccl.Framework.Factory.ValueConverters
{
    public class BooleanValueSetter : IValueSetter
    {
        public void Set(object instance, PropertyInfo property, string value)
        {
            bool val = true;
            if (!string.IsNullOrEmpty(value))
            {
                bool.TryParse(value, out val);
            }
            property.SetValue(instance, val);
        }
    }
}