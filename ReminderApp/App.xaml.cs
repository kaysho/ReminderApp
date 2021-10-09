using Xamarin.Forms;

namespace ReminderApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            Current.UserAppTheme = OSAppTheme.Light;
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
