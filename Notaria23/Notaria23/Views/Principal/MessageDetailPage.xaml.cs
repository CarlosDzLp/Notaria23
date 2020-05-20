using System;
using System.Collections.Generic;
using Notaria23.Models.User;
using Notaria23.ViewModels.Principal;
using Xamarin.Forms;

namespace Notaria23.Views.Principal
{
    public partial class MessageDetailPage : ContentPage
    {
        public MessageDetailPage(UserModel user)
        {
            InitializeComponent();
            this.BindingContext = new MessageDetailPageViewModel(user);
        }
    }
}
