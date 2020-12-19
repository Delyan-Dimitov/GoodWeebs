namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Entities.Maps;
    using GoodWeebs.Data.Common.Models;

    public class Anime : ISeries, IDeletableEntity, IAuditInfo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Genres { get; set; }

        public string Picture { get; set; }

        public int CurrentCount { get; set; }

        public int FinishedCount { get; set; }

        public string Type { get; set; }

        public string Synopsis { get; set; }

        public string Episodes { get; set; }

        public string Status { get; set; }

        public string Aired { get; set; }

        public string Synonyms { get; set; }

        public string Trailer { get; set; }

        public string EpisodeDuration { get; set; }

        public string Rating { get; set; }

        public string Studios { get; set; }

        public ICollection<CurrentlyWatchingMap> CurrentlyWatching { get; set; }

        public ICollection<WatchedMap> WatchedAnime { get; set; }

        public ICollection<WantToWatchMap> WantToWatch { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
