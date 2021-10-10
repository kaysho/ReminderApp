using System;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ReminderApp.Converter
{
    public class ExpiredReminderDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            var difference = DateTime.Now - dateTime;
            StringBuilder stringBuilder = new StringBuilder("Reminder elapsed ");
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

            stringBuilder.Append("ago");
            return stringBuilder.ToString();
            //return $"Reminder elapsed {difference.Days} day(s) {difference.Hours} hour(s) {difference.Minutes} minute(s) ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
