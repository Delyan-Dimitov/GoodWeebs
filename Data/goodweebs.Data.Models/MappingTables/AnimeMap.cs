namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;

    public class AnimeMap : IMap, IDeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AnimeId { get; set; }

        public Anime Anime { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}