using System;

namespace ccl.Framework.Commands.Attributes.Method
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        public string Text { get; private set; }

        public DescriptionAttribute(string text)
        {
            Text = text;
        }
    }
}