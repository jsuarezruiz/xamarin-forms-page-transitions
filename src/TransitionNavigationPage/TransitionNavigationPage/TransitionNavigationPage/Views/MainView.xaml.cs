using TransitionNavigationPage.Enums;
using TransitionNavigationPage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TransitionNavigationPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage, (sender, arg) => 
            {
                var transitionType = (TransitionType)arg;
                var transitionNavigationPage = Parent as Controls.TransitionNavigationPage;

                if (transitionNavigationPage != null)
                {
                    transitionNavigationPage.TransitionType = transitionType;
                    Navigation.PushAsync(new DetailView());
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage);
        }
    }
}
