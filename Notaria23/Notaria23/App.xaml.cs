using System;
using Notaria23.Controls;
using Notaria23.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notaria23
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetailPage { get; set; }
        public App()
        {
            InitializeComponent();
           
            MainPage = new Views.Principal.MasterPage();         
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
