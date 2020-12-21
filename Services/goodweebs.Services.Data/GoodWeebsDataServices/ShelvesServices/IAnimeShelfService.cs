namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    using global::GoodWeebs.Web.ViewModels.ShelfViewModels;
    using System.Threading.Tasks;

    public interface IAnimeShelfService
    {
        public Task AddToWatched(string userId, int animeId);

        public Task AddToWatching(string userId, int animeId);

        public Task AddToWantToWatch(string userId, int animeId);

        public Task RemoveFromWatched(string userId, int animeId);

        public Task RemoveFromWatching(string userId, int animeId);

        public Task RemoveFromWant(string userId, int animeId);

        public Task<ShelfViewModel> GetWatched(string userId);

        public Task<ShelfViewModel> GetWantToWatch(string userId);

        public Task<ShelfViewModel> GetWatching(string userId);
    }
}
