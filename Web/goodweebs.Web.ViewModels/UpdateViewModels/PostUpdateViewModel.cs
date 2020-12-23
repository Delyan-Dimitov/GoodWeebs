using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.UpdateViewModels
{
    public class PostUpdateViewModel
    {
        public const string PostContentTemplate = "{0} posted: {1} in {2}";

        public string UserDisplayName { get; set; }

        public int UpdateId { get; set; }

        public int PostId { get; set; }

        public string GroupName { get; set; }

        public string Content { get; set; }
    }
}
