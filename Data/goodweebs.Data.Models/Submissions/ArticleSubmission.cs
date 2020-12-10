namespace Goodweebs.Data.Models.Submissions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class ArticleSubmission : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser Submitter { get; set; }

        public string SubbmiterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set ; }

        public DateTime? ModifiedOn { get; set; }
    }
}
