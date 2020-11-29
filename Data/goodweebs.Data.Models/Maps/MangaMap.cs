namespace Entities.Maps
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GoodWeebs.Data.Models;

  public class MangaMap :IMap
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int MangaId { get; set; }

        public Manga Manga { get; set; }
    }
}
