using System;
using ReminderApp.Models;
using Xamarin.Forms;

namespace ReminderApp.Template
{
    public class ReminderDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ExpiredReminderTemplate { get; set; }
        public DataTemplate OngoingReminderTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var reminder = (Reminder)item;
            var dateTime = reminder.Date;
            return dateTime > DateTime.Now ? OngoingReminderTemplate : ExpiredReminderTemplate;
        }
    }
}
