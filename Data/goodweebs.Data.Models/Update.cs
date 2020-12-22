namespace GoodWeebs.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;
    using goodweebs.Data.Models;

    public class Update : IDeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string UserDisplayName { get; set; }
        public string ContentTitle { get; set; }

        public ApplicationUser User { get; set; }

        public int Type { get; set; } // 1 - Anime upadte ; 2 - MangaUpdate ;  2 - post in group

        public string UserId { get; set; }

        public int ContentId { get; set; } // Series Id / PostId

        public Group Group { get; set; }

        public int? GroupId { get; set; }

        public string UpdateContent { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
