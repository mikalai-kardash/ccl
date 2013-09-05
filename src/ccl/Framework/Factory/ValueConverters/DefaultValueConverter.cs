namespace ccl.Framework.Factory.ValueConverters
{
    public class DefaultValueConverter : IValueConverter
    {
        public object GetValue(string value)
        {
            return value;
        }
    }
}