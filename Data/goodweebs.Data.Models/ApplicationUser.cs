// ReSharper disable VirtualMemberCallInConstructor
namespace GoodWeebs.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Entities;
    using Entities.Maps;
    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models.Submissions;
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
            this.AnimeSubmissions = new HashSet<AnimeSubmission>();
            this.MangaSubmissions = new HashSet<MangaSubmission>();
            this.ArticleSubmissions = new HashSet<ArticleSubmission>();
        }

        public string DisplayName { get; set; }

        public string AvatarUrl { get; set; }

        public int SubmissionsCount { get; set; }

        public virtual ICollection<CurrentlyWatchingMap> CurrentlyWatching { get; set; }

        public virtual ICollection<WatchedMap> Watched { get; set; }

        public virtual ICollection<WantToWatchMap> WantToWatch { get; set; }

        public virtual ICollection<CurrentlyReadingMap> CurrentlyReading { get; set; }

        public virtual ICollection<ReadMap> Read { get; set; }

        public virtual ICollection<WantToReadMap> WantToRead { get; set; }

        public virtual ICollection<Friends> MainUserFriends { get; set; }

        public virtual ICollection<Friends> Friends { get; set; }

        public virtual ICollection<AnimeSubmission> AnimeSubmissions { get; set; }

        public virtual ICollection<MangaSubmission> MangaSubmissions { get; set; }

        public virtual ICollection<ArticleSubmission> ArticleSubmissions { get; set; }

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
