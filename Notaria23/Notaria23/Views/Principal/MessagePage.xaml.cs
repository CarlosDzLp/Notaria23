using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Principal;
using Xamarin.Forms;

namespace Notaria23.Views.Principal
{
    public partial class MessagePage : ContentPage
    {
        public MessagePage()
        {
            InitializeComponent();
            this.BindingContext = new MessagePageViewModel();
        }
    }
}
