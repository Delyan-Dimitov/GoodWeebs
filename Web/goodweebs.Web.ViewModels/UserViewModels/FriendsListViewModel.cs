namespace GoodWeebs.Web.ViewModels.UserViewModels
{
    using System.Collections.Generic;

    public class FriendsListViewModel
    {
        public ICollection<ProfileViewModel> Friends { get; set; }
    }
}
