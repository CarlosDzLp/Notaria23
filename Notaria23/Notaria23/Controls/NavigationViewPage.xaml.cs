using System;
using System.Collections.Generic;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.Controls
{
    public partial class NavigationViewPage : NavigationPage
    {
        public NavigationViewPage()
        {
            InitializeComponent();
            this.BindingContext = new BindableBase();
        }
        public NavigationViewPage(Page root):base(root)
        {
            InitializeComponent();
            this.BindingContext = new BindableBase();
        }
    }
}
