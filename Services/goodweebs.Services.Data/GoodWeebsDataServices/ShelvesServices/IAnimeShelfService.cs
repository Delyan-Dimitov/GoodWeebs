using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices
{
    public interface IAnimeShelfService
    {
        public Task AddToWatched(string userId, int animeId);

        public Task AddToWatching(string userId, int animeId);

        public Task AddToWantToWatch(string userId, int animeId);

        public Task RemoveFromWatched(string userId, int animeId);

        public Task RemoveFromWatching(string userId, int animeId);

        public Task RemoveFromWant(string userId, int animeId);
    }
}
