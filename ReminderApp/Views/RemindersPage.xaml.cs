using System;
using System.Collections.Generic;
using ReminderApp.ViewModels;
using Xamarin.Forms;

namespace ReminderApp.Views
{
    public partial class RemindersPage : ContentPage
    {
        RemindersViewModel _viewModel;
        public RemindersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RemindersViewModel();
        }
    }
}
