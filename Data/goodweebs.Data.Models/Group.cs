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
            this.Posts = new HashSet<Post>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ApplicationUser Admin { get; set; }

        public string AdminId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
