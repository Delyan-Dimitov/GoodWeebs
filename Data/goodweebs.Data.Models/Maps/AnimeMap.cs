namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using GoodWeebs.Data.Models;

    public class AnimeMap : IMap

    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

    }
}
