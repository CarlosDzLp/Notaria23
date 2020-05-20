using System;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using Notaria23.DataBase;
using Notaria23.Helpers;
using Notaria23.Models.Authenticate;
using Notaria23.Models.User;
using Notaria23.Service;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Principal
{
    public class AccountPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();

        #region Properties
        public UserModel User { get; set; }
        #endregion

        #region Constructor
        public AccountPageViewModel()
        {
            User = DbContext.Instance.GetUser();
            DownloadImage(User.Image);
            UpdateCommand = new Command(UpdateCommandExecuted);
            LogOutCommand = new Command(LogOutCommandExecuted);
            LoadPhotoCommand = new Command(LoadPhotoCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand UpdateCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand LoadPhotoCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void UpdateCommandExecuted()
        {
            if(User.ImageByte == null)
            {
                Toast("Cargue una imagen");
                return;
            }
            if(string.IsNullOrWhiteSpace(User.Name))
            {
                Toast("Ingrese un nombre");
                return;
            }
            if (string.IsNullOrWhiteSpace(User.LastName))
            {
                Toast("Ingrese un apellido");
                return;
            }
            if (string.IsNullOrWhiteSpace(User.Email))
            {
                Toast("Ingrese un correo");
                return;
            }
            if (string.IsNullOrWhiteSpace(User.User))
            {
                Toast("Ingrese un usuario");
                return;
            }
            if (string.IsNullOrWhiteSpace(User.Password))
            {
                Toast("Ingrese una contraseña");
                return;
            }
            if (string.IsNullOrWhiteSpace(User.Telephone))
            {
                Toast("Ingrese un telefono");
                return;
            }
            try
            {
                Show("Actualizando datos....");
                var response = await client.Put<Response<bool>, UserModel>(User, "user/updateuser");
                Hide();
                if (response != null)
                {
                    if(response.Result && response.Count > 0)
                    {
                        DbContext.Instance.DeleteUser();
                        DbContext.Instance.InsertUser(User);
                        User = DbContext.Instance.GetUser();
                    }
                    else
                        Toast("Algo salio mal intente mas tarde");
                }
                else
                    Toast("Algo salio mal intente mas tarde");
            }
            catch(Exception ex)
            {
                Hide();
            }
        }
        private void LogOutCommandExecuted()
        {
            try
            {
                DbContext.Instance.DeleteUser();
                App.Current.MainPage = new NavigationPage(new Views.Session.LoginPage())
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#5B2273")
                };
            }
            catch(Exception ex)
            {

            }
        }
        private async void LoadPhotoCommandExecuted()
        {
            string answer = await App.Current.MainPage.DisplayActionSheet("Notaria 23", "Cancelar", null, "Camara", "Galeria");
            if (!string.IsNullOrWhiteSpace(answer))
            {
                if (answer == "Galeria")
                {
                    var status = await Notaria23.Helpers.Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Storage);
                    if (status)
                    {
                        User.ImageByte = await PhotoCamera.PickPhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
                else if (answer == "Camara")
                {
                    var status = await Notaria23.Helpers.Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                    if (status)
                    {
                        User.ImageByte = await PhotoCamera.TakePhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
            }
        }

        private async void DownloadImage(string url)
        {
            if(string.IsNullOrWhiteSpace(url))
            {
                User.ImageByte = null;
                return;
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        streamToReadFrom.CopyTo(ms);
                        User.ImageByte = ms.ToArray();
                    }                    
                }
            }
        }
        #endregion
    }
}
