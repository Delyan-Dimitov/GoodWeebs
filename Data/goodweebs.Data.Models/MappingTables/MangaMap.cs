namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using GoodWeebs.Data.Models;

    public class MangaMap : IMap
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int MangaId { get; set; }

        [Required]
        public Manga Manga { get; set; }
    }
}
