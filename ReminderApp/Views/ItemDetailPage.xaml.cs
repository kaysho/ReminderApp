using System.ComponentModel;
using Xamarin.Forms;
using ReminderApp.ViewModels;

namespace ReminderApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
