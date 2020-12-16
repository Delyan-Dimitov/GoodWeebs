namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
{
    using System;
    using System.Collections.Generic;
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
        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> GenresItems { get; set; } = new List<string> { "Action", "Aventure", "Cars", "Comedy", "Demons", "Drama", "Ecchi", "Fantasy", "Harem", "Hentai", "Historical", "Horror", "Kids", "Magic", "Martial Arts", "Mecha", "Music", "Mystery", "Parody", "Police", "Romance", "Samurai", "School", "Sci-Fi", "Shoujo", "Shoujo Ai", "Shounen", "Shounen Ai", "Space", "Sports", "Super Power", "Supernatural", "Vampire", "Yaoi", "Yuri" };

        [Required]
        [Url]
        public string PictureUrl { get; set; }

        [Required]
        public string Type { get; set; }

        public IEnumerable<string> TypeItems { get; set; } = new List<string> { "Manga", "Manhwa", "Novel", "Doujinshi", "One-shot" };

        [Required]
        [MinLength(50)]
        [MaxLength(1000)]
        public string Synopsis { get; set; }

        [Required]
        public string Status { get; set; }

        public IEnumerable<string> StatusItems { get; set; } = new List<string> { "Publishing", "Finished", "On Hiatus", "Discontinued" };

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
        public string Authors { get; set; }

        public int DbId { get; set; } = 0;
    }
}
