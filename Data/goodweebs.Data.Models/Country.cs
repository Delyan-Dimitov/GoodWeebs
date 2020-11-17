using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Country 
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int UserCount { get; set; }
        
    }
}
