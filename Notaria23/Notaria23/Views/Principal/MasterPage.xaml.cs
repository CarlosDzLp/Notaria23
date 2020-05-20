using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notaria23.DataBase;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notaria23.Views.Principal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : TabbedPage
    {
        public MasterPage()
        {
            InitializeComponent();
            var user = DbContext.Instance.GetUser();
            if(user.UserType == 0)
            {
                //USUARIO
                Children.Add(new MessagePage());
                Children.Add(new VideoCallPage());
                Children.Add(new AccountPage());
            }
            else
            {
                //ADMINISTRADOR
                Children.Add(new MessagePage());
                Children.Add(new VideoCallPage());
                Children.Add(new UserEnabledPage());
                Children.Add(new AccountPage());
            }
        }
    }
}
