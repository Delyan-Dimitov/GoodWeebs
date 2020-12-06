namespace Goodweebs.Data.Models.Submissions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class MangaSubmission : IAuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public string SubmissionType { get; set; }

        public string SubmitterId { get; set; }

        public string SubmissionUrl { get; set; }

        public ApplicationUser Submitter { get; set; }

        public string Title { get; set; }

        public string Genres { get; set; }

        public string Picture { get; set; }

        public string Type { get; set; }

        public string Synopsis { get; set; }

        public string Episodes { get; set; }

        public string Status { get; set; }

        public string Aired { get; set; }

        public string Synonyms { get; set; }

        public string Trailer { get; set; }

        public string EpisodeDuration { get; set; }

        public string Rating { get; set; }

        public string Studios { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
