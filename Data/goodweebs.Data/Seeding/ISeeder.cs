namespace GoodWeebs.Data.Seeding
{
    using Azure.Storage.Blobs;
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
