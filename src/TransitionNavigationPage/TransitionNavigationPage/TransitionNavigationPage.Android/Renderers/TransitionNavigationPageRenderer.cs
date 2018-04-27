using System.ComponentModel;
using Android.Content;
using Android.Support.V4.App;
using TransitionNavigationPage.Droid.Renderers;
using TransitionNavigationPage.Enums;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TransitionNavigationPage.Controls.TransitionNavigationPage), typeof(TransitionNavigationPageRenderer))]
namespace TransitionNavigationPage.Droid.Renderers
{
    public class TransitionNavigationPageRenderer : NavigationPageRenderer
    {
        private TransitionType _transitionType = TransitionType.Default;

        public TransitionNavigationPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Controls.TransitionNavigationPage.TransitionTypeProperty.PropertyName)
                UpdateTransitionType();
        }

        protected override void SetupPageTransition(FragmentTransaction transaction, bool isPush)
        {
            switch (_transitionType)
            {
                case TransitionType.None:
                    return;
                case TransitionType.Default:
                    return;
                case TransitionType.Fade:
                    transaction.SetCustomAnimations(Resource.Animation.fade_in, Resource.Animation.fade_out,
                                                    Resource.Animation.fade_out, Resource.Animation.fade_in);
                    break;
                case TransitionType.Flip:
                    transaction.SetCustomAnimations(Resource.Animation.flip_in, Resource.Animation.flip_out,
                                                    Resource.Animation.flip_out, Resource.Animation.flip_in);
                    break;
                case TransitionType.Scale:
                    transaction.SetCustomAnimations(Resource.Animation.scale_in, Resource.Animation.scale_out,
                                                    Resource.Animation.scale_out, Resource.Animation.scale_in);
                    break;
                case TransitionType.SlideFromLeft:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    }
                    break;
                case TransitionType.SlideFromRight:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
                                                        Resource.Animation.enter_left, Resource.Animation.exit_right);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_left, Resource.Animation.exit_right,
                                                        Resource.Animation.enter_right, Resource.Animation.exit_left);
                    }
                    break;
                case TransitionType.SlideFromTop:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    }
                    break;
                case TransitionType.SlideFromBottom:
                    if (isPush)
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_bottom, Resource.Animation.exit_top,
                                                        Resource.Animation.enter_top, Resource.Animation.exit_bottom);
                    }
                    else
                    {
                        transaction.SetCustomAnimations(Resource.Animation.enter_top, Resource.Animation.exit_bottom,
                                                        Resource.Animation.enter_bottom, Resource.Animation.exit_top);
                    }
                    break;
                default:
                    return;
            }
        }

        private void UpdateTransitionType()
        {
            var transitionNavigationPage = (Controls.TransitionNavigationPage)Element;
            _transitionType = transitionNavigationPage.TransitionType;
        }
    }
}
