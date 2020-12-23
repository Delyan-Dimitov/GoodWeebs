namespace GoodWeebs.Data.Models.MappingTables
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Common.Models;

    public class UsersGroups : IDeletableEntity, IAuditInfo
    {
        [Key]
        public int Key { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string GroupId { get; set; }

        public Group Group { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
