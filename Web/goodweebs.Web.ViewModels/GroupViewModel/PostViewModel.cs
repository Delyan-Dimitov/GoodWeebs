namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    using System.Collections.Generic;

    public class PostViewModel
    {
        public PostViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PosterId { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
