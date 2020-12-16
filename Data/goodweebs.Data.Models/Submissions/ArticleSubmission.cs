namespace GoodWeebs.Data.Models.Submissions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using GoodWeebs.Data.Models.Submissions;
    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class ArticleSubmission : IAuditInfo, IDeletableEntity, ISubmission
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser Submitter { get; set; }

        public string SubmitterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public string Status { get; set; } = "Pending";

        public string ApprovalStatus { get; set; } = "Pending";

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set ; }

        public DateTime? ModifiedOn { get; set; }
    }
}
