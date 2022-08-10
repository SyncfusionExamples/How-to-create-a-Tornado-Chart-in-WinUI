using Microsoft.UI.Xaml.Data;
using System;

namespace WinUI_TornadoChart
{
    public class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Change the negative values into absolute value.
            return Math.Abs(System.Convert.ToDouble(value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
