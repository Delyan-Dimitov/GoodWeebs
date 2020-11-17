using Entities.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class AnimeHelperTable : Series
    {
        public AnimeHelperTable()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public ICollection<CurrentlyWatchingMap> CurrentlyWatching { get; set; }

        public ICollection<WatchedMap> WatchedAnime { get; set; }

        public ICollection<WantToWatchMap> WantToWatch { get; set; }
    }
}
