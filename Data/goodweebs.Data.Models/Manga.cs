using Entities.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Manga : ISeries
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Genre { get; set; }

        public int CurrentCount { get; set; }

        public int FinishedCount { get; set; }

        public bool IsFinished { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime DateFinished { get; set; }

        public ICollection<CurrentlyReadingMap> CurrentlyReading { get; set; }

        public ICollection<ReadMap> Read { get; set; }

        public ICollection<WantToReadMap> WantToRead { get; set; }


    }
}
