using Entities.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Manga : Series
    {
        public Manga()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }
        public ICollection<CurrentlyReadingMap> CurrentlyReading { get; set; }

        public ICollection<ReadMap> Read { get; set; }

        public ICollection<WantToReadMap> WantToRead { get; set; }
    }
}
