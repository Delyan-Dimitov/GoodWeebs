namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Entities.Maps;

    public class Manga : ISeries
    {

        public int Id { get; set; }

        [Required]
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

        public ICollection<CurrentlyReadingMap> CurrentlyReading { get; set; }

        public ICollection<ReadMap> Read { get; set; }

        public ICollection<WantToReadMap> WantToRead { get; set; }

    }
}
