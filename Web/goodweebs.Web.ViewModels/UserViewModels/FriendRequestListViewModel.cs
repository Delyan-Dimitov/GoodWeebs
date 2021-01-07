using GoodWeebs.Web.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.UserViewModels
{
    public class FriendRequestListViewModel
    {
        public FriendRequestListViewModel()
        {
            FriendRequests = new List<FriendRequestViewModel>();
        }
       public ICollection<FriendRequestViewModel> FriendRequests { get; set; }
    }
}
