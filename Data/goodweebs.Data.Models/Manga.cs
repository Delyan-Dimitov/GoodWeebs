namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Entities.Maps;
    using GoodWeebs.Data.Common.Models;

    public class Manga : IDeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Synopsis { get; set; }

        public string Genres { get; set; }

        public string Type { get; set; }

        public string Volumes { get; set; }

        public string Chapters { get; set; }

        public string Published { get; set; }

        public string Authors { get; set; }

        public string Status { get; set; }

        public string PictureUrl { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateFinished { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
