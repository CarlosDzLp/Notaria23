using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Principal;
using Xamarin.Forms;

namespace Notaria23.Views.Principal
{
    public partial class VideoCallPage : ContentPage
    {
        public VideoCallPage()
        {
            InitializeComponent();
            this.BindingContext = new VideoCallPageViewModel();
        }
    }
}
