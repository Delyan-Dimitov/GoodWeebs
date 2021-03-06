﻿namespace Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class Friends : IAuditInfo, IDeletableEntity
    {
        public Friends()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string MainUserId { get; set; }

        [Required]
        public ApplicationUser MainUser { get; set; }

        [Required]
        public string FriendUserId { get; set; }

        [Required]
        public ApplicationUser FriendUser { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
