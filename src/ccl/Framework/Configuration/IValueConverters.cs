using ccl.Framework.Factory.ValueConverters;

namespace ccl.Framework.Configuration
{
    public interface IValueConverters
    {
        IValueConverters Add(IValueConverter converter);
        IValueConverters Clear();
    }
}