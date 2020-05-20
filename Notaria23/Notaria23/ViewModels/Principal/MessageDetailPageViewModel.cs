using System;
using Notaria23.Models.User;
using Notaria23.ViewModels.Base;

namespace Notaria23.ViewModels.Principal
{
    public class MessageDetailPageViewModel : BindableBase
    {
        #region Constructor
        public MessageDetailPageViewModel(UserModel user)
        {
            Title = user.Name;
        }
        #endregion
    }
}
