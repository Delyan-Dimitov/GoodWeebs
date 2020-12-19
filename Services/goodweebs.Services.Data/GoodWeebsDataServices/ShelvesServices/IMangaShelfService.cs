namespace GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using System.Threading.Tasks;

    public interface IMangaShelfService
    {
        public Task AddToRead(string userId, int mangaId);

        public Task AddToReading(string userId, int mangaId);

        public Task AddToWant(string userId, int mangaId);

        public Task RemoveFromRead(string userId, int mangaId);

        public Task RemoveFromReading(string userId, int mangaId);

        public Task RemoveFromWant(string userId, int mangaId);
    }
}
