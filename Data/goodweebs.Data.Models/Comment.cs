namespace GoodWeebs.Data.Models
{
    using GoodWeebs.Data.Common.Models;
    using System;

    public class Comment : IDeletableEntity, IAuditInfo
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

        public string PostId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
