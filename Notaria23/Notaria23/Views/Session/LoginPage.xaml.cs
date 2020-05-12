using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Session;
using Xamarin.Forms;

namespace Notaria23.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
        }
    }
}
