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

namespace Notaria23.ViewModels.Principal
{
    public class MessagePageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();

        #region Properties
        public bool IsRefreshing { get; set; }
        public ObservableCollection<UserModel> ListUserMessage { get; set; }
        #endregion

        #region Constructor
        public MessagePageViewModel()
        {
            LoadUserMessage();
            MessagingCenter.Subscribe<UserEnabledPageViewModel>(this, "sendenabled", (e) =>
            {
                LoadUserMessage();
            });
            RetryCommand = new Command(LoadUserMessageRetry);
            SelectedUserMessage = new Command<UserModel>(SelectedUserMessageExecuted);
        }
        #endregion

        #region Methods
        private async void LoadUserMessage()
        {
            try
            {
                Isvisible = true;
                IsVisibleEmpty = false;
                IsRefreshing = true;
                var user = DbContext.Instance.GetUser();
                ListUserMessage = new ObservableCollection<UserModel>();
                ListUserMessage.Clear();
                var response = await client.Get<Response<List<UserModel>>>("user/userall");
                IsRefreshing = false;
                if (response != null)
                {
                    if (response.Result != null && response.Count > 0)
                    {
                        var result = response.Result.Where(c => c.IsEnabled == true && c.UserId != user.UserId).ToList();
                        if(result.Count > 0)
                        {
                            Isvisible = true;
                            IsVisibleEmpty = false;
                            foreach (var item in result)
                            {
                                ListUserMessage.Add(item);
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
                IsRefreshing = false;
            }
        }
        private async void LoadUserMessageRetry()
        {
            try
            {
                var user = DbContext.Instance.GetUser();
                ListUserMessage = new ObservableCollection<UserModel>();
                ListUserMessage.Clear();
                Show("Obteniendo datos....");
                var response = await client.Get<Response<List<UserModel>>>("user/userall");
                Hide();
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
                                ListUserMessage.Add(item);
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
        public ICommand RetryCommand { get; set; }
        public ICommand SelectedUserMessage { get; set; }
        #endregion

        #region CommandExecuted
        private void SelectedUserMessageExecuted(UserModel obj)
        {
            if(obj != null)
            {
                App.Current.MainPage.Navigation.PushAsync(new Views.Principal.MessageDetailPage(obj));
            }
        }
        #endregion
    }
}
