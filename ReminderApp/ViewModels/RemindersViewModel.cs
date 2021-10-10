using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        #region Properties

        public ObservableCollection<Reminder> Reminders { get; set; }

        public Command AddReminderCommand { get; }
        public Command DeleteCommand { get; }

        public string Reminder
        {
            set
            {
                LoadReminder(value);
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default contructor
        /// </summary>
        public RemindersViewModel()
        {
            Title = "Reminders";
            AddReminderCommand = new Command(OnAddReminder);
            DeleteCommand = new Command(OnDeleteReminder);
            Reminders = new ObservableCollection<Reminder>();
        }

        
        #endregion

        #region Methods
        /// <summary>
        /// Load reminder
        /// </summary>
        /// <param name="value"></param>
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
                Debug.WriteLine("Failed to serialize reminder",ex);
            }
        }
        /// <summary>
        /// Delete reminder
        /// </summary>
        /// <param name="obj"></param>
        private async void OnDeleteReminder(object obj)
        {
            var reminder = (Reminder)obj;

            if (reminder == null)
                return;

            var result = await Application.Current.MainPage.DisplayAlert("Confirmation","Are you sure you want to delete reminder?","Yes","No");
            if (result)
            {
                Reminders.Remove(reminder);

            }
        }

        /// <summary>
        /// Navigate to add reminder page.
        /// </summary>
        /// <param name="obj"></param>
        private async void OnAddReminder(object obj) => await Shell.Current.GoToAsync(nameof(NewReminderPage));
        #endregion
    }
}
