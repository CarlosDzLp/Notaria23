using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Notaria23.Helpers;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Base
{
    public class BindableBase : INotifyPropertyChanged
    {
        #region Properties
        private string title;

        public string Title
        {
            get;
            set;
        }
        #endregion

        
        #region NotifyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        IDialogs dial = null;
        #region Constructor
        public BindableBase()
        {
            dial = DependencyService.Get<IDialogs>();
        }
        #endregion

        #region Dialogs
        public void Snack(string message, string title, TypeSnackbar typeSnack)
        {
            dial.Snackbar(message, title, typeSnack);
        }
        public void Toast(string message)
        {
            dial.Toast(message);
        }
        public void Hide()
        {
            dial.Hide();
        }
        public void Show(string message)
        {
            dial.Show(message);
        }
        #endregion
    }
}
