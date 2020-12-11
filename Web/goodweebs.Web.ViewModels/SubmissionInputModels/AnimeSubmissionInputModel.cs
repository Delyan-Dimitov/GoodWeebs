namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class AnimeSubmissionInputModel
    {
        public string SubmissionUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Url(ErrorMessage = "PLease submit a valid url" )]
        public string PictureUrl { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Synopsis too long!")]
        [MaxLength(1000)]
        public string Synopsis { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "To many or too few episodes!")]
        public int Episodes { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [Range(1, 180, ErrorMessage = "Duration is too short or too long!")]
        public int Duration { get; set; }

        [Required]
        [RegularExpression(@"^(\d{4} - \d{4})$", ErrorMessage = "Incorrect Format! (YYYY - YYYY)")]
        public string Aired { get; set; }

        [Required]
        public string Studios { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Genres { get; set; }

        [Required]
        public string Status { get; set; }

        public string Synonyms { get; set; }

        [Url]
        public string Trailer { get; set; }
    }
}
