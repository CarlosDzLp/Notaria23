using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notaria23
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Session.LoginPage())
            {
                BarBackgroundColor = Color.White,
                BarTextColor = Color.FromHex("#5B2273")
            };
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
