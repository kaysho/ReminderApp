using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ReminderApp.Converter
{
    public class OngoingReminderDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            var difference = dateTime - DateTime.Now;
            StringBuilder stringBuilder = new StringBuilder("Reminder clocks in ");
            if (difference.Days != 0)
            {
                stringBuilder.Append($"{difference.Days} day(s) ");
            }
            if (difference.Hours != 0)
            {
                stringBuilder.Append($"{difference.Hours} hour(s) ");
            }

            if (difference.Minutes != 0)
            {
                stringBuilder.Append($"{difference.Minutes} minute(s) ");
            }
            if (difference.Seconds != 0)
            {
                stringBuilder.Append($"{difference.Seconds} second(s) ");
            }

            return stringBuilder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
