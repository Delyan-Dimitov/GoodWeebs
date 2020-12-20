namespace GoodWeebs.Web.ViewModels.UserViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FriendRequestViewModel
    {
        public string Id { get; set; }

        public ProfileViewModel Sender { get; set; }

    }
}
