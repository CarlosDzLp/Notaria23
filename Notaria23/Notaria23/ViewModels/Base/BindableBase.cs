using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Notaria23.Helpers;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Base
{
    public class BindableBase : INotifyPropertyChanged
    {
        #region Properties
        public string Title
        {
            get;
            set;
        }
        public bool Isvisible { get; set; }
        public bool IsVisibleEmpty { get; set; }
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
            AddVideoCallCommand = new Command(AddVideoCallCommandExecuted);
        }

        
        #endregion

        #region Command
        public ICommand AddVideoCallCommand { get; set; }
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

        #region CommandExecuted
        private void AddVideoCallCommandExecuted()
        {
            PopupNavigation.Instance.PushAsync(new Views.Principal.Popup.CreateSessionViewCallPopup());
        }
        #endregion
    }
}
