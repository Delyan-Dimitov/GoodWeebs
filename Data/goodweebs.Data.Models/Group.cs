using System;
using System.Collections.Generic;

namespace GoodWeebs.Data.Models
{
    public class Group
    {
        public Group()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Post> Posts { get; set; } // TODO make post model

        public ApplicationUser Admin { get; set; }

    }
}
