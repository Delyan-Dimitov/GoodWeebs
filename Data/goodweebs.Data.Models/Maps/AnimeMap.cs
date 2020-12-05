namespace Entities.Maps
{
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Models;

    public class AnimeMap : IMap
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int AnimeId { get; set; }

        [Required]
        public Anime Anime { get; set; }
    }
}
