namespace GoodWeebs.Web.ViewModels.ShelfViewModels
{
    using System.Collections.Generic;

    using GoodWeebs.Web.ViewModels.ShelfViewModels;

    public class ShelfViewModel
    {

        public ShelfViewModel()
        {
            this.ShelfItems = new List<ShelfItemVIewModel>();
        }

        public string ProfileId { get; set; }

        public ICollection<ShelfItemVIewModel> ShelfItems { get; set; }

        public bool MyProfile { get; set; }
    }
}
