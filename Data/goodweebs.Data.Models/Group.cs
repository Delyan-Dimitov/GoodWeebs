using GoodWeebs.Data.Common.Models;
using System;
using System.Collections.Generic;

namespace GoodWeebs.Data.Models
{
    public class Group : IDeletableEntity , IAuditInfo
    {
        public Group()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Post> Posts { get; set; } // TODO make post model

        public ApplicationUser Admin { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
