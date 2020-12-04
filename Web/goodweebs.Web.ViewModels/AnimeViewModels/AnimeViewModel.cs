using System;
using System.Collections.Generic;
using System.Text;

namespace goodweebs.Web.ViewModels.AnimeViewModels
{
   public class AnimeViewModel
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public string PictureUrl { get; set; }

        public string Synopsis { get; set; }

        public string Episodes { get; set; } = "Unknown";

        public string Type { get; set; } = "Unknown";

        public string Duration { get; set; } = "Unknown";

        public string Aired { get; set; } = "Unknown";

        public string Studios { get; set; } = "Unknown";

        public string Rating { get; set; } = "Unknown";

        public string Genres { get; set; } = "Unknown";
        public string Status { get; set; }
    }
}
