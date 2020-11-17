namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class WatchedMap : AnimeMap
    {
        public DateTime DateStarted { get; set; }

        public DateTime DateFinished { get; set; }
    }
}
