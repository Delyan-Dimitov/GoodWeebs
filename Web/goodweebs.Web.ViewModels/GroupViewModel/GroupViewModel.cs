namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    using GoodWeebs.Data.Models;
    using System.Collections.Generic;

    public class GroupViewModel

    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ApplicationUser Admin { get; set; }

        public List<PostInListViewModel> Posts { get; set; };
    }
}
