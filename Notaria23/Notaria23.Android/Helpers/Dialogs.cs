using System;
using System.Threading.Tasks;
using AndroidHUD;
using Notaria23.Droid.Helpers;
using Notaria23.Helpers;
using Org.Aviran.CookieBar2;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Dialogs))]
namespace Notaria23.Droid.Helpers
{
    public class Dialogs : IDialogs
    {
        public async Task Show(string message)
        {
            AndHUD.Shared.Show(CrossCurrentActivity.Current.Activity, message, -1, MaskType.Black, null, null, true, null);
        }

        public async Task Hide()
        {
            AndHUD.Shared.Dismiss();
        }

        public async Task Snackbar(string message, string title, TypeSnackbar typeSnackbar)
        {
            if (typeSnackbar == TypeSnackbar.Success)
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                   // .SetIcon(Resource.Drawable.ic_done)
                .SetTitle(title)
                .SetIconAnimation(Resource.Animator.iconspin)
                .SetBackgroundColor(Resource.Color.backgroundcoockiesuccess)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
            else
            {
                CookieBar.Build(CrossCurrentActivity.Current.Activity)
                   // .SetIcon(Resource.Drawable.ic_error)
                .SetTitle(title)
                .SetIconAnimation(Resource.Animator.iconspin)
                .SetBackgroundColor(Resource.Color.backgroundcoockieerror)
                .SetTitleColor(Resource.Color.cookiebartitle)
                .SetMessageColor(Resource.Color.cookiebartitle)
                .SetMessage(message)
                .SetEnableAutoDismiss(true)
                .SetSwipeToDismiss(true)
                .Show();
            }
        }

        public async Task Toast(string message)
        {
            var toast = Android.Widget.Toast.MakeText(CrossCurrentActivity.Current.Activity, message, Android.Widget.ToastLength.Short);
            toast.Show();
        }
    }
}
