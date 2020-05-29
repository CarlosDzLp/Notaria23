using System;
using Notaria23.ViewModels.Base;
using Xamarin.Forms;

namespace Notaria23.Models.Menus
{
    public class MenuModel : BindableNotify
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public string Img { get; set; }
        public Type TargetType { get; set; }
    }
}
