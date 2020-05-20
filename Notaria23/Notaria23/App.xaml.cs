using System;
using Notaria23.Controls;
using Notaria23.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notaria23
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var user = DbContext.Instance.GetUser();
            if (user != null)
            {
                MainPage = new NavigationViewPage(new Views.Principal.MasterPage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.Session.LoginPage())
                {
                    BarTextColor = Color.White,
                    BarBackgroundColor = Color.FromHex("#5B2273")
                };
            }           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
