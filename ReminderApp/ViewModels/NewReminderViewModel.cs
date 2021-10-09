using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReminderApp.Models;
using Xamarin.Forms;

namespace ReminderApp.ViewModels
{
    public class NewReminderViewModel : BaseViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private string text;
        private string description;
        public DateTime MinimumDate { get; set; } = DateTime.Now;
        public TimeSpan MinimumTime { get; set; }
        private DateTime reminderDate;
        private TimeSpan remindertime;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public DateTime ReminderDate
        {
            get => reminderDate;
            set => SetProperty(ref reminderDate, value);
        }
        public TimeSpan ReminderTime
        {
            get => remindertime;
            set => SetProperty(ref remindertime, value);
        }

        public NewReminderViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            ReminderDate = DateTime.Now;
            remindertime = DateTime.Now.TimeOfDay;
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description)
                && (remindertime > DateTime.Now.TimeOfDay); 
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {

            ReminderDate = new DateTime(reminderDate.Year,reminderDate.Month,reminderDate.Day, remindertime.Hours, remindertime.Minutes,remindertime.Seconds) ;
            Reminder reminder = new Reminder
            {
                Title = Text,
                Description = Description,
                Date = ReminderDate,
                Id = Guid.NewGuid().ToString()
            };

            var json = JsonConvert.SerializeObject(reminder);
            await Shell.Current.GoToAsync($"..?reminder={json}");
        }
    }
}
