namespace GoodWeebs.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Entities;
    using global::GoodWeebs.Web.ViewModels.AnimeViewModels;
    using global::GoodWeebs.Web.ViewModels.SubmissionInputModels;

    public interface IAnimeService
    {
        ICollection<AnimeInListViewModel> GetAll(int page, int itemsPerPage);

        Task<IEnumerable<AnimeInListViewModel>> GetTopGlobalAsync(int amount);

        int GetCount();

        AnimeViewModel GetById(int id);

        IEnumerable<AnimeViewModel> GetSimilar(int id, int amount);

        IEnumerable<AnimeViewModel> GetBestHits(IEnumerable<string> targets, IEnumerable<AnimeViewModel> collection, int amount);

    }
}
