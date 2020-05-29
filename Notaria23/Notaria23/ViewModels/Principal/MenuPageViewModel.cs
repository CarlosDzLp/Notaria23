using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Notaria23.Models.Menus;
using Notaria23.Utils;
using Notaria23.ViewModels.Base;
using Notaria23.Views.Principal;
using Xamarin.Forms;

namespace Notaria23.ViewModels.Principal
{
    public class MenuPageViewModel : BindableBase
    {
        #region Properties
        public ObservableCollection<MenuModel> ListMenu { get; set; }
        #endregion

        #region Constructor
        public MenuPageViewModel()
        {
            LoadMenu();
            SelectedItemMenuCommand = new Command<MenuModel>(SelectedItemMenuCommandExecuted);
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            try
            {
                ListMenu = new ObservableCollection<MenuModel>();
                ListMenu.Clear();
                ListMenu.Add(new MenuModel { BackgroundColor = Color.FromHex("#5B2273"), TextColor = Color.White, Title = "Inicio", ID = 0, Img = FontAwesomeIcons.Home,TargetType=typeof(HomePage) });
                ListMenu.Add(new MenuModel { BackgroundColor = Color.White, TextColor = Color.FromHex("#5B2273"), Title = "Notaria", ID = 1, Img = FontAwesomeIcons.Notaria, TargetType = typeof(NotaryPage) });
                ListMenu.Add(new MenuModel { BackgroundColor = Color.White, TextColor = Color.FromHex("#5B2273"), Title = "Tramites en linea", ID = 2, Img = FontAwesomeIcons.Online, TargetType = typeof(OnlinePage) });
                ListMenu.Add(new MenuModel { BackgroundColor = Color.White, TextColor = Color.FromHex("#5B2273"), Title = "Requisitos", ID = 3, Img = FontAwesomeIcons.Requisitos, TargetType = typeof(DocumentsPage) });
                ListMenu.Add(new MenuModel { BackgroundColor = Color.White, TextColor = Color.FromHex("#5B2273"), Title = "Directorio", ID = 4, Img = FontAwesomeIcons.Directorio, TargetType = typeof(DirectoryPage) });
                ListMenu.Add(new MenuModel { BackgroundColor = Color.White, TextColor = Color.FromHex("#5B2273"), Title = "Contacto", ID = 5, Img = FontAwesomeIcons.Contacto, TargetType = typeof(ContactPage) });
            }
            catch (Exception ex)
            {

            }
        }
        private void ResetMenu(MenuModel menu)
        {
            foreach(var item in ListMenu)
            {
                if(item.ID == menu.ID)
                {
                    item.TextColor = Color.White;
                    item.BackgroundColor = Color.FromHex("#5B2273");
                }
                else
                {
                    item.BackgroundColor = Color.White;
                    item.TextColor = Color.FromHex("#5B2273");
                }
            }
        }
        
        #endregion

        #region Command
        public ICommand SelectedItemMenuCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void SelectedItemMenuCommandExecuted(MenuModel menuModel)
        {
            try
            {
                ResetMenu(menuModel);
                NavigationAsync(menuModel);
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
