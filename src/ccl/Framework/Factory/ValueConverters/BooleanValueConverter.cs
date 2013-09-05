namespace ccl.Framework.Factory.ValueConverters
{
    public class BooleanValueConverter : IValueConverter
    {
        public object GetValue(string value)
        {
            var val = true;
            if (!string.IsNullOrEmpty(value))
            {
                bool.TryParse(value, out val);
            }
            return val;
        }
    }
}