﻿namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
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
        [Url(ErrorMessage = "PLease submit a valid url")]
        public string PictureUrl { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Synopsis too short!")]
        [MaxLength(1000)]
        public string Synopsis { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "To many or too few episodes!")]
        public int Episodes { get; set; }

        [Required]
        public string Type { get; set; }

        public List<string> TypeItems { get; set; } = new List<string> { "R+ Mild Nudity", "G - All Ages", "PG - Children", "R - 17+ (Violence & Profanity)", "PG 13 Teens 13 Or Older", "Rx - Hentai" };


        [Required]
        [Range(1, 180, ErrorMessage = "Duration is too short or too long!")]
        public int Duration { get; set; }

        [Required]
        [RegularExpression(@"^(\d{4} - \d{4})$", ErrorMessage = "Incorrect Format! (YYYY - YYYY)")]
        public string Aired { get; set; }

        [Required]
        public string Studio { get; set; }

        [Required]
        public string Rating { get; set; }

        public List<string> RatingItems { get; set; } = new List<string> { "TV", "OVA", "Movie", "Special" };

        [Required]
        public IEnumerable<string> Genres { get; set; }

        public IEnumerable<string> GenresItems { get; set; } = new List<string> { "Action", "Aventure", "Cars", "Comedy", "Demons", "Drama", "Ecchi", "Fantasy", "Harem", "Hentai", "Historical", "Horror", "Kids", "Magic", "Martial Arts", "Mecha", "Music", "Mystery", "Parody", "Police", "Romance", "Samurai", "School", "Sci-Fi", "Shoujo", "Shoujo Ai", "Shounen", "Shounen Ai", "Space", "Sports", "Super Power", "Supernatural", "Vampire", "Yaoi", "Yuri" };

        [Required]
        public string Status { get; set; }

        public List<string> StatusItems { get; set; } = new List<string> { "Currently Airing", "Finished Airing" };

        public string Synonyms { get; set; }

        [Url]
        public string Trailer { get; set; }

        public string SubmitterId { get; set; }

        public int DbId { get; set; }
     }
}
