using System;
using System.Collections.Generic;
using ReminderApp.ViewModels;
using ReminderApp.Views;
using Xamarin.Forms;

namespace ReminderApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewReminderPage), typeof(NewReminderPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
