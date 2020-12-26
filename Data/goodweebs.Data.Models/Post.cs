namespace GoodWeebs.Data.Models
{
    using GoodWeebs.Data.Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Post : IDeletableEntity, IAuditInfo
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ApplicationUser Poster { get; set; }

        public string PosterDisplayName { get; set; }

        public string PosterId { get; set; }

        public Group Group { get; set; }

        public string GroupId { get; set; }

        public int Likes { get; set; } = 0;

        public ICollection<Comment> Comments { get; set; }

        public int CommentCount { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
