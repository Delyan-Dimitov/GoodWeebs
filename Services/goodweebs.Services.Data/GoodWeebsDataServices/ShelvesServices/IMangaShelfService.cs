namespace GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using GoodWeebs.Web.ViewModels.ShelfViewModels;
    using System.Threading.Tasks;

    public interface IMangaShelfService
    {
        public Task<bool> AddToRead(string userId, int mangaId);

        public Task<bool> AddToReading(string userId, int mangaId);

        public Task<bool> AddToWant(string userId, int mangaId);

        public Task RemoveFromRead(string userId, int mangaId);

        public Task RemoveFromReading(string userId, int mangaId);

        public Task RemoveFromWant(string userId, int mangaId);

        public Task<ShelfViewModel> GetRead(string userId);

        public Task<ShelfViewModel> GetReading(string userId);

        public Task<ShelfViewModel> GetWantToRead(string userId);
    }
}
