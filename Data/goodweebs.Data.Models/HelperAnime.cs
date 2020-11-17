namespace Goodweebs.Data.Models
{
    using goodweebs.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HelperAnime
    {
        [Key]
        public int Id { get; set; }

        public string Sources { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int Episodes { get; set; }

        public string Status { get; set; }

        public string AnimeSeason { get; set; }

        public string Picture { get; set; }

        public string Thumbnail { get; set; }

        public string Synonyms { get; set; }

        public string Relations { get; set; }

        public string Tags { get; set; }
    }
}
