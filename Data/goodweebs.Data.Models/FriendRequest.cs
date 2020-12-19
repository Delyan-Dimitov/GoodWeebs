namespace GoodWeebs.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;

    public class FriendRequest : IDeletableEntity, IAuditInfo

    {
        public FriendRequest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public ApplicationUser Requester { get; set; }

        public string RequesterId { get; set; }

        public ApplicationUser Requestee { get; set; }

        public string RequesteeId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
