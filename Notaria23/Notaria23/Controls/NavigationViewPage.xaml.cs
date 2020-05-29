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
            
        }
        public NavigationViewPage(Page root):base(root)
        {
            InitializeComponent();
            
        }
    }
}
