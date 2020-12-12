namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Models;

    public class MangaSubmissionInputModel
    {
        public string SubmissionType { get; set; }

        public string SubmitterId { get; set; }

        public string SubmissionUrl { get; set; }

        public ApplicationUser Submitter { get; set; }

        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        [Url]
        public string Picture { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(1000)]
        public string Synopsis { get; set; }

        [Required]
        public string Status { get; set; }

        public string Synonyms { get; set; }

        [Required]
        [Range(1, 1000)]

        public int Volumes { get; set; }

        [Required]
        [Range(1, 10000)]
        public string Chapters { get; set; }

        [Required]
        [RegularExpression(@"\d{4}$")]
        public string Published { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Authors { get; set; }
    }
}
