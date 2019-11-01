using System;
using System.Globalization;
using Xamarin.Forms;


namespace DominicanWhoCodes.Helpers.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var inputValue = (string)value;

            return !string.IsNullOrEmpty(inputValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}