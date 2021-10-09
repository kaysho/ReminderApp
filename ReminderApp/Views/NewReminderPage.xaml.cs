using System;
using System.Collections.Generic;
using ReminderApp.ViewModels;
using Xamarin.Forms;

namespace ReminderApp.Views
{
    public partial class NewReminderPage : ContentPage
    {
        public NewReminderPage()
        {
            InitializeComponent();

            BindingContext = new NewReminderViewModel();
        }
    }
}
