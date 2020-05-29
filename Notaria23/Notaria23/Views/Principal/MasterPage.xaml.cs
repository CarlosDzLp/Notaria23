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
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.MasterDetailPage = this;
        }
    }
}
