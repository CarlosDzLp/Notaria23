using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Principal.Popup;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Notaria23.Views.Principal.Popup
{
    public partial class CreateSessionViewCallPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public CreateSessionViewCallPopup()
        {
            InitializeComponent();
            this.BindingContext = new CreateSessionViewCallPopupViewModel();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PopAllAsync();
        }
    }
}
