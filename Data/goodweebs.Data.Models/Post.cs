namespace GoodWeebs.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser Poster { get; set; }

        public string PosterId { get; set; }

        public int Likes { get; set; } = 0;

        public ICollection<Comment> Comments { get; set; }

        public int CommentCount { get; set; }
    }
}
