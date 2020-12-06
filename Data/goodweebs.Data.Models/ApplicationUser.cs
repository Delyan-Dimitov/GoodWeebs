// ReSharper disable VirtualMemberCallInConstructor
namespace GoodWeebs.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Entities;
    using Entities.Maps;
    using Goodweebs.Data.Models.Submissions;
    using GoodWeebs.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.CurrentlyWatching = new HashSet<CurrentlyWatchingMap>();
            this.Watched = new HashSet<WatchedMap>();
            this.WantToWatch = new HashSet<WantToWatchMap>();
            this.CurrentlyReading = new HashSet<CurrentlyReadingMap>();
            this.Read = new HashSet<ReadMap>();
            this.WantToRead = new HashSet<WantToReadMap>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        public string Country { get; set; }

        public bool LikesAnime { get; set; }

        public bool LikesManga { get; set; }

        public string AvatarUrl { get; set; }

        public virtual ICollection<CurrentlyWatchingMap> CurrentlyWatching { get; set; }

        public virtual ICollection<WatchedMap> Watched { get; set; }

        public virtual ICollection<WantToWatchMap> WantToWatch { get; set; }

        public virtual ICollection<CurrentlyReadingMap> CurrentlyReading { get; set; }

        public virtual ICollection<ReadMap> Read { get; set; }

        public virtual ICollection<WantToReadMap> WantToRead { get; set; }

        public virtual ICollection<Friends> MainUserFriends { get; set; }

        public virtual ICollection<Friends> Friends { get; set; }

        public virtual ICollection<AnimeSumbission> ArticleSumbissions { get; set; }

        public virtual ICollection<MangaSubmission>MangaSumbissions { get; set; }

        public virtual ICollection<ArticleSumbission> AnimeSumbissions { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
