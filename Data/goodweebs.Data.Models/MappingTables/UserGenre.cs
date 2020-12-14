namespace GoodWeebs.Data.Models.MappingTables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using GoodWeebs.Data.Models;

    public class UserGenre
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Genre { get; set; }

        public int Count { get; set; }
    }
}
