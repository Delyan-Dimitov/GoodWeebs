namespace GoodWeebs.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class Article : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(5)]
        public string Title { get; set; }

        [MinLength(100)]
        public string Content { get; set; }

        public ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
