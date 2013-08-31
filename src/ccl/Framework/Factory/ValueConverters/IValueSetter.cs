using System.Reflection;

namespace ccl.Framework.Factory.ValueConverters
{
    public interface IValueSetter
    {
        void Set(object instance, PropertyInfo property, string value);
    }
}