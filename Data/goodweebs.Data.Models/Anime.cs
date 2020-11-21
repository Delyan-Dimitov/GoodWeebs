using Entities.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Anime : Series
    {

        public ICollection<CurrentlyWatchingMap> CurrentlyWatching { get; set; }

        public ICollection<WatchedMap> WatchedAnime { get; set; }

        public ICollection<WantToWatchMap> WantToWatch { get; set; }
    }
}
