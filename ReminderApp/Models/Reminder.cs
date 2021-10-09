using System;
using Newtonsoft.Json;

namespace ReminderApp.Models
{
    public class Reminder
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Reminder()
        {
            Id = new Guid().ToString();
        }
    }
}
