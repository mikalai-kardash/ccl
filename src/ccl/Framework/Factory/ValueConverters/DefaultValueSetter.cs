using System.Reflection;

namespace ccl.Framework.Factory.ValueConverters
{
    public class DefaultValueSetter : IValueSetter
    {
        public void Set(object instance, PropertyInfo property, string value)
        {
            property.SetValue(instance, value);
        }
    }
}