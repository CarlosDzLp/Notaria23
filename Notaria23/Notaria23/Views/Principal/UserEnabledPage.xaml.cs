using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Principal;
using Xamarin.Forms;

namespace Notaria23.Views.Principal
{
    public partial class UserEnabledPage : ContentPage
    {
        public UserEnabledPage()
        {
            InitializeComponent();
            this.BindingContext = new UserEnabledPageViewModel();
        }
    }
}
