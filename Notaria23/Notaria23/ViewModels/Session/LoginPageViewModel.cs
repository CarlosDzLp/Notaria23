using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Constructor
        public LoginPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecuted);
            SigInCommand = new Command(SigInCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        public ICommand SigInCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void RegisterCommandExecuted()
        {
            App.Current.MainPage.Navigation.PushAsync(new Views.Session.RegisterPage());
        }
        private async void SigInCommandExecuted()
        {
            Show("Cargando....");
            await Task.Delay(TimeSpan.FromSeconds(5));
            Hide();
            App.Current.MainPage = new Views.Principal.MasterPage();
        }
        #endregion
    }
}
