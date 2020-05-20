using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Notaria23.Controls;
using Notaria23.DataBase;
using Notaria23.Models.Authenticate;
using Notaria23.Models.User;
using Notaria23.Service;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        public string User { get; set; }
        public string Password { get; set; }
        #endregion
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
            try
            {
                if (string.IsNullOrWhiteSpace(User))
                {
                    Toast("Ingrese un usuario");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Password))
                {
                    Toast("Ingrese una contraseña");
                    return;
                }
                Show("Cargando....");
                var user = new AuthenticateModel();
                user.User = User;
                user.Password = Password;
                var response = await client.Post<Response<UserModel>, AuthenticateModel>(user, "user/userlogin");
                Hide();
                if (response != null)
                {
                    if (response.Result != null)
                    {
                        DbContext.Instance.InsertUser(response.Result);
                        App.Current.MainPage = new NavigationViewPage(new Views.Principal.MasterPage());
                    }
                    else
                    {
                        Toast("Usuario incorrectos");
                    }
                }
                else
                {
                    Toast("Algo salio mal intentelo mas tarde");
                }
            }
            catch(Exception ex)
            {
                Hide();
                Toast(ex.Message);
            }
        }
        #endregion
    }
}
