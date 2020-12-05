namespace GoodWeebs.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Entities;
    using global::GoodWeebs.Web.ViewModels.AnimeViewModels;

    public interface IAnimeService
    {
        IEnumerable<AnimeInListViewModel> GetAll(int page, int itemsPerPage);

        Task<IEnumerable<Anime>> GetTopGlobalAsync(int amount);

        int GetCount();

        AnimeViewModel GetById(int id);

        IEnumerable<AnimeViewModel> GetSimilar(int id, int amount);

        IEnumerable<AnimeViewModel> GetBestHits(IEnumerable<string> targets, IEnumerable<AnimeViewModel> collection, int amount);

        Task CreateAsync(AnimeSubmissionInputModel anime, string userId, string subType);
    }
}
