namespace GoodWeebs.Web.ViewModels.UserViewModels
{
    using System.Collections.Generic;

    public class FriendsListViewModel
    {
        public FriendsListViewModel()
        {
            this.Friends = new List<ProfileViewModel>();
        }
        public ICollection<ProfileViewModel> Friends { get; set; }
    }
}
