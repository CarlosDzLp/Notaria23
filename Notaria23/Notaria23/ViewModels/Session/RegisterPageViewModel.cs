using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;
using Notaria23.Helpers;
using Notaria23.Models.User;
using Notaria23.Service;
using Notaria23.Models.Authenticate;
using Notaria23.DataBase;

namespace Notaria23.ViewModels.Session
{
    public class RegisterPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient(); 
        #region Properties
        public byte[] Photo{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(RegisterCommandExecuted);
            LoadPhotoCommand = new Command(LoadPhotoCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand RegisterCommand { get; set; }
        public ICommand LoadPhotoCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void RegisterCommandExecuted()
        {
            try
            {
                if(Photo == null)
                {
                    Toast("Agregue una imagen");
                    return;
                }
                if(string.IsNullOrWhiteSpace(Name))
                {
                    Toast("Ingrese un nombre");
                    return;
                }
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    Toast("Ingrese sus apellidos");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Email))
                {
                    Toast("Ingrese un correo");
                    return;
                }
                if (string.IsNullOrWhiteSpace(Telephone))
                {
                    Toast("Ingrese un telefono");
                    return;
                }
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
                Show("Enviando datos......");
                var responseemail = await client.Get<Response<UserModel>>($"user/useremail?email={Email}");
                Hide();
                if(responseemail != null)
                {
                    if(responseemail.Result != null && responseemail.Count > 0)
                    {
                        Toast("El Correo ya existe, ingrese otro");
                    }
                    else
                    {
                        var user = new UserModel();
                        user.Name = Name;
                        user.LastName = LastName;
                        user.Email = Email;
                        user.User = User;
                        user.Password = Password;
                        user.Image = string.Empty;
                        user.Telephone = Telephone;
                        user.UserId = Guid.NewGuid();
                        user.IsEnabled = false;
                        user.UserType = 0;
                        user.Status = true;
                        user.DateCreated = DateTime.Now;
                        user.DateModified = DateTime.Now;
                        user.ImageByte = Photo;
                        Show("Enviando datos......");
                        var response = await client.Post<Response<bool>, UserModel>(user, "user/insertuser");
                        Hide();
                        if (response != null)
                        {
                            if (response.Result && response.Count > 0)
                            {
                                Toast("Espere a que un administrador habilite su acceso");
                            }
                            else
                            {
                                Toast(response.Message);
                            }
                        }
                        else
                        {
                            Toast("Algo salio mal, intente mas tarde");
                        }
                    }
                }
                else
                {
                    Toast("Algo salio mal intente mas tarde");
                }  
            }
            catch(Exception ex)
            {
                Hide();
                Toast(ex.Message);
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
                        Photo = await PhotoCamera.PickPhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
                else if(answer == "Camara")
                {
                    var status = await Notaria23.Helpers.Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                    if (status)
                    {
                        Photo = await PhotoCamera.TakePhoto();
                    }
                    else
                    {
                        Toast("Habilite los permisos requeridos");
                    }
                }
            }
        }
        #endregion
    }
}
