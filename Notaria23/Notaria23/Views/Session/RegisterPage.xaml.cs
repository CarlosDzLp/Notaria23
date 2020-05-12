using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Session;
using Xamarin.Forms;

namespace Notaria23.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterPageViewModel();
        }
    }
}
