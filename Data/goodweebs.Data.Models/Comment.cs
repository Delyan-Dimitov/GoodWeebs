namespace GoodWeebs.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Comment
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser Commenter { get; set; }

        public string CommenterId { get; set; }

        public Post Post { get; set; }

        public int Likes { get; set; } = 0;

    }
}
