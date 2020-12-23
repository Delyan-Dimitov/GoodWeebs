using System.Collections.Generic;

namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    public class GroupListViewModel
    {
        public GroupListViewModel()
        {
            this.Groups = new List<GroupInListViewModel>();
        }
        public ICollection<GroupInListViewModel> Groups { get; set; }
    }
}
