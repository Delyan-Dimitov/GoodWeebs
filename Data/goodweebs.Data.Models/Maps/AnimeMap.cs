namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using goodweebs.Data.Models;

    public class AnimeMap : IMap

    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string AnimeId { get; set; }

        public AnimeHelperTable Anime { get; set; }

    }
}
