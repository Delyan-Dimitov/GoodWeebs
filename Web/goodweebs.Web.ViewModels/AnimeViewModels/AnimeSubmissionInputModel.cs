using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace goodweebs.Web.ViewModels.AnimeViewModels
{
    public class AnimeSubmissionInputModel
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public string PictureUrl { get; set; }

        public string Synopsis { get; set; }

        public string Episodes { get; set; }

        public string Type { get; set; }

        public string Duration { get; set; }

        public string Aired { get; set; }

        public IEnumerable<string> Studios { get; set; }

        public string Rating { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public string Status { get; set; }

        public IEnumerable<string> GenresInput { get; set; }
    }
}
