using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Session
{
    public class RegisterPageViewModel : BindableBase
    {
        #region Constructor
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void RegisterCommandExecuted()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            App.Current.MainPage = new Views.Principal.MasterPage();
        }
        #endregion
    }
}
