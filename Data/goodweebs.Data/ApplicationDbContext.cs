namespace GoodWeebs.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Maps;
    using GoodWeebs.Data.Common.Models;
    using GoodWeebs.Data.Models;
    using Goodweebs.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Anime> Animes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Manga> Mangas { get; set; }

        public DbSet<WatchedMap> WatchedMaps { get; set; }

        public DbSet<CurrentlyWatchingMap> CurrentlyWatchingMaps { get; set; }

        public DbSet<WantToWatchMap> WantToWatchMaps { get; set; }

        public DbSet<CurrentlyReadingMap> CurrentlyReadingMaps { get; set; }

        public DbSet<ReadMap> ReadMaps { get; set; }

        public DbSet<WantToReadMap> WantToReadMaps { get; set; }

        public DbSet<Friends> Friends { get; set; }

        public DbSet<HelperAnime> HelperAnimes { get; set; }
        public object Anime { get; internal set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<WatchedMap>()
               .HasKey(wm => new {wm.UserId, wm.AnimeId});
            builder.Entity<WatchedMap>()
                .HasOne(wm => wm.User)
                .WithMany(u => u.Watched)
                .HasForeignKey(wm => wm.UserId);
            builder.Entity<WatchedMap>()
                .HasOne(wm => wm.Anime)
                .WithMany(a => a.WatchedAnime)
                .HasForeignKey(wm => wm.AnimeId);
            //

            builder.Entity<CurrentlyWatchingMap>()
                .HasKey(cw => new { cw.UserId, cw.AnimeId });
            builder.Entity<CurrentlyWatchingMap>()
                .HasOne(cw => cw.User)
                .WithMany(u => u.CurrentlyWatching)
                .HasForeignKey(cw => cw.UserId);
            builder.Entity<CurrentlyWatchingMap>()
                .HasOne(cw => cw.Anime)
                .WithMany(a => a.CurrentlyWatching)
                .HasForeignKey(cw => cw.AnimeId);
            //

            builder.Entity<WantToWatchMap>()
                .HasKey(ww => new { ww.UserId, ww.AnimeId });
            builder.Entity<WantToWatchMap>()
                .HasOne(ww => ww.User)
                .WithMany(u => u.WantToWatch)
                .HasForeignKey(ww => ww.UserId);
            builder.Entity<WantToWatchMap>()
                .HasOne(ww => ww.Anime)
                .WithMany(a => a.WantToWatch)
                .HasForeignKey(ww => ww.AnimeId);
            //

            builder.Entity<CurrentlyReadingMap>()
                .HasKey(cr => new { cr.UserId, cr.MangaId });
            builder.Entity<CurrentlyReadingMap>()
                .HasOne(cr => cr.User)
                .WithMany(u => u.CurrentlyReading)
                .HasForeignKey(cr => cr.UserId);
            builder.Entity<CurrentlyReadingMap>()
            .HasOne(cr => cr.Manga)
            .WithMany(m => m.CurrentlyReading)
            .HasForeignKey(cr => cr.MangaId);
            //
            builder.Entity<WantToReadMap>()
                .HasKey(cr => new { cr.UserId, cr.MangaId });
            builder.Entity<WantToReadMap>()
                .HasOne(cr => cr.User)
                .WithMany(u => u.WantToRead)
                .HasForeignKey(cr => cr.UserId);
            builder.Entity<WantToReadMap>()
            .HasOne(cr => cr.Manga)
            .WithMany(m => m.WantToRead)
            .HasForeignKey(cr => cr.MangaId);
            //
            builder.Entity<ReadMap>()
              .HasKey(cr => new { cr.UserId, cr.MangaId });
            builder.Entity<ReadMap>()
                .HasOne(cr => cr.User)
                .WithMany(u => u.Read)
                .HasForeignKey(cr => cr.UserId);
            builder.Entity<ReadMap>()
            .HasOne(cr => cr.Manga)
            .WithMany(m => m.Read)
            .HasForeignKey(cr => cr.MangaId);
            //

            builder.Entity<Friends>()
      .HasKey(f => new { f.MainUserId, f.FriendUserId });

            builder.Entity<Friends>()
                .HasOne(f => f.MainUser)
                .WithMany(mu => mu.MainUserFriends)
                .HasForeignKey(f => f.MainUserId).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Friends>()
                .HasOne(f => f.FriendUser)
                .WithMany(mu => mu.Friends)
                .HasForeignKey(f => f.FriendUserId);

        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
