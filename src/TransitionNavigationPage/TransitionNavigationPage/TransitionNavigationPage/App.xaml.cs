using TransitionNavigationPage.Views;
using Xamarin.Forms;

namespace TransitionNavigationPage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Controls.TransitionNavigationPage(new MainView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
