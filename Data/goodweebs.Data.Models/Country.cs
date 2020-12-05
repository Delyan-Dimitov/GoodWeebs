namespace Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
