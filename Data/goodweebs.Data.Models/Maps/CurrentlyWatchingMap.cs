namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

   public class CurrentlyWatchingMap : AnimeMap
    {
        [Required]
        public DateTime DateStarted { get; set; }
    }
}
