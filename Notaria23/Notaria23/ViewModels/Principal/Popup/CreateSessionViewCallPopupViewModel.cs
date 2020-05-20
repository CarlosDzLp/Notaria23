using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Notaria23.DataBase;
using Notaria23.Models.Authenticate;
using Notaria23.Models.User;
using Notaria23.Service;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Principal.Popup
{
    public class CreateSessionViewCallPopupViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();

        #region Properties
        public ObservableCollection<UserModel> ListUserCall { get; set; }
        public bool IsRefresh { get; set; }
        #endregion

        #region Constructor
        public CreateSessionViewCallPopupViewModel()
        {
            LoadUserCall();
            CreateVideoCommand = new Command(CreateVideoCommandExecuted);
        }
        #endregion

        #region Methods
        private async void LoadUserCall()
        {
            try
            {
                IsRefresh = true;
                var user = DbContext.Instance.GetUser();
                ListUserCall = new ObservableCollection<UserModel>();
                ListUserCall.Clear();
                var response = await client.Get<Response<List<UserModel>>>("user/userall");
                IsRefresh = false;
                if (response != null)
                {
                    if (response.Result != null && response.Count > 0)
                    {
                        var result = response.Result.Where(c => c.IsEnabled == true && c.UserId != user.UserId).ToList();
                        if (result.Count > 0)
                        {
                            Isvisible = true;
                            IsVisibleEmpty = false;
                            foreach (var item in result)
                            {
                                ListUserCall.Add(item);
                            }
                        }
                        else
                        {
                            Isvisible = false;
                            IsVisibleEmpty = true;
                        }
                    }
                    else
                    {
                        Isvisible = false;
                        IsVisibleEmpty = true;
                    }
                }
                else
                {
                    Isvisible = false;
                    IsVisibleEmpty = true;
                }
            }
            catch (Exception ex)
            {
                IsRefresh = false;
            }
        }
        #endregion

        #region Command
        public ICommand CreateVideoCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void CreateVideoCommandExecuted()
        {
            Toast("Crea la video llamada");
        }
        #endregion
    }
}
