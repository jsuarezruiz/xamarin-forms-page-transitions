using System.Windows.Input;
using TransitionNavigationPage.Controls;
using Xamarin.Forms;

namespace TransitionNavigationPage.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ICommand FadeCommand => new Command(Fade);
        public ICommand FlipCommand => new Command(Flip);
        public ICommand ScaleCommand => new Command(Scale);
        public ICommand SlideFromLeftCommand => new Command(SlideFromLeft);
        public ICommand SlideFromRightCommand => new Command(SlideFromRight);
        public ICommand SlideFromTopCommand => new Command(SlideFromTop);
        public ICommand SlideFromBottomCommand => new Command(SlideFromBottom);

        private void Fade()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.Fade);
        }

        private void Flip()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.Flip);
        }

        private void Scale()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.Scale);
        }

        private void SlideFromLeft()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.SlideFromLeft);
        }

        private void SlideFromRight()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.SlideFromRight);
        }

        private void SlideFromTop()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.SlideFromTop);
        }

        private void SlideFromBottom()
        {
            MessagingCenter.Send(this, AppSettings.TransitionMessage, TransitionType.SlideFromBottom);
        }
    }
}