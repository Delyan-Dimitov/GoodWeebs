using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.UpdateViewModels
{
    public class UpdateListViewModel
    {
        public ICollection<SeriesUpdateViewModel> SeriesUpdates { get; set; }

        public ICollection<PostUpdateViewModel> PostUpdates { get; set; }
    }
}
