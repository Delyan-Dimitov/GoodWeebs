namespace GoodWeebs.Data.Models.MappingTables
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;

    public class GroupsPosts : IDeletableEntity, IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string GroupId { get; set; }

        public Group Group { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}