using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Notaria23.Models.Authenticate;
using Notaria23.Models.User;
using Notaria23.Service;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Principal
{
    public class UserEnabledPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        public ObservableCollection<UserModel>ListUserEnabled{ get; set; }
        #endregion

        #region Constructor
        public UserEnabledPageViewModel()
        {
            LoadUserEnabled();
            SelectedItemUserEnabled = new Command<UserModel>(SelectedItemUserEnabledExecuted);
            RetryCommand = new Command(LoadUserEnabledRetry);
        }
        #endregion

        #region Methods
        private async void LoadUserEnabled()
        {
            try
            {
                ListUserEnabled = new ObservableCollection<UserModel>();
                ListUserEnabled.Clear();
                var response = await client.Get<Response<List<UserModel>>>("user/userall");
                if (response != null)
                {
                    if (response.Result != null && response.Count > 0)
                    {
                        var result = response.Result.Where(c => c.IsEnabled == false).ToList();
                        if(result.Count > 0)
                        {
                            Isvisible = true;
                            IsVisibleEmpty = false;
                            foreach (var item in result)
                            {
                                ListUserEnabled.Add(item);
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
            catch(Exception ex)
            {

            }
        }
        private async void LoadUserEnabledRetry()
        {
            try
            {
                ListUserEnabled = new ObservableCollection<UserModel>();
                ListUserEnabled.Clear();
                Show("Obteniendo datos...");
                var response = await client.Get<Response<List<UserModel>>>("user/userall");
                Hide();
                if (response != null)
                {
                    if (response.Result != null && response.Count > 0)
                    {
                        var result = response.Result.Where(c => c.IsEnabled == false).ToList();
                        if (result.Count > 0)
                        {
                            Isvisible = true;
                            IsVisibleEmpty = false;
                            foreach (var item in result)
                            {
                                ListUserEnabled.Add(item);
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

            }
        }
        #endregion

        #region Command
        public ICommand SelectedItemUserEnabled { get; set; }
        public ICommand RetryCommand { get; set; }
        #endregion

        #region CommandExecuted
        public async void SelectedItemUserEnabledExecuted(UserModel user)
        {
            try
            {
                if(user != null)
                {
                    bool answer = await App.Current.MainPage.DisplayAlert("Notaria 23", $"Desea habilitar el usuario {user.Name}", "Si", "No");
                    if(answer)
                    {
                        Show("Habilitando el usuario");
                        var response = await client.Get<Response<bool>>($"user/enableduser?userID={user.UserId}");
                        Hide();
                        if(response != null)
                        {
                            if(response.Result && response.Count > 0)
                            {
                                LoadUserEnabled();
                                MessagingCenter.Send<UserEnabledPageViewModel>(this, "sendenabled");
                            }
                            else
                            {
                                Toast("No se pudo habiliatr el usuario");
                            }
                        }
                        else
                        {
                            Toast("Algo salio mal intente mas tarde");
                        }
                    }                   
                }
            }
            catch(Exception ex)
            {
                Hide();
            }
        }
        #endregion
    }
}
