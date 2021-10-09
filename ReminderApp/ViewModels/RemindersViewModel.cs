using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReminderApp.Models;
using ReminderApp.Views;
using Xamarin.Forms;

namespace ReminderApp.ViewModels
{
    [QueryProperty(nameof(Reminder), "reminder")]
    public class RemindersViewModel : BaseViewModel
    {
        public ObservableCollection<Reminder> Reminders { get; set; }

        public Command AddReminderCommand { get; }

        public string Reminder
        {
            set
            {
                LoadReminder(value);
            }
        }

        private void LoadReminder(string value)
        {
            try
            {
                if (value == null)
                {
                    return;
                }
                var reminder = JsonConvert.DeserializeObject<Reminder>(value);
                if (Reminders.Where(r => r.Id == reminder.Id).SingleOrDefault() != null)
                {
                    return;
                }
                Reminders.Add(reminder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to serialize reminder");
            }
        }

        public RemindersViewModel()
        {
            Title = "Reminders";
            AddReminderCommand = new Command(OnAddReminder);
            Reminders = new ObservableCollection<Reminder>();
            //Reminders = new ObservableCollection<Reminder> { new Reminder { Title ="Grocies", Description ="dlsdkksldskkf" },new Reminder { Title = "Grocies", Description = "dlsdkksldskkf" }, new Reminder { Title = "Grocies", Description = "dlsdkksldskkf" }, new Reminder { Title = "Grocies Spending", Date = DateTime.UtcNow.AddDays(-3), Description = "dlsdkksldskkf" } };
        }

        private async void OnAddReminder(object obj)
        {
            Reminder = null;
            await Shell.Current.GoToAsync(nameof(NewReminderPage));
        }


    }
}
