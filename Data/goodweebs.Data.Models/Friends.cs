using goodweebs.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Friends
    {
        public Friends()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string MainUserId { get; set; }

        public ApplicationUser MainUser { get; set; }

        public string FriendUserId { get; set; }

        public ApplicationUser FriendUser { get; set; }

        [Required]
        public DateTime FriendsSince { get; set; }
    }
}
