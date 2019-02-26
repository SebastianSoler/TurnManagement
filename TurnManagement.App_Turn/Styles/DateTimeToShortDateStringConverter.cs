using System;
using System.Windows.Data;

namespace TurnManagement.App_Turn.Styles
{
    public class DateTimeToShortDateStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            DateTime dateTimeValue = (DateTime)value;

            string param = parameter != null ? parameter.ToString() : string.Empty;
            if (param == string.Empty)
                param = "MM/dd";

            return dateTimeValue.ToString(param);
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
