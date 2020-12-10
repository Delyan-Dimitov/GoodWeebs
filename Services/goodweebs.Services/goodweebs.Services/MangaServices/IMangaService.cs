namespace GoodWeebs.Services.GoodWeebs.Services.MangaServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Entities;
    using global::GoodWeebs.Web.ViewModels.MangaViewModels;

    public interface IMangaService
    {
       IEnumerable<MangaInListViewModel> GetAll(int page, int itemsPerPage);

       MangaViewModel GetInfoById(int id);

       Task<IEnumerable<MangaViewModel>> GetTopGlobalAsync(int amount); // TODO MAKE THE ANIME VERSION OF THIS RETURN VIEW MODEL TOO

       IEnumerable<MangaViewModel> GetViewModels(IEnumerable<Manga> mangas);

       IEnumerable<MangaViewModel> GetSimilar(int id, int amount);

       IEnumerable<MangaViewModel> GetBestHits(IEnumerable<string> targets, IEnumerable<MangaViewModel> collection, int amount);

       int GetCount();
    }
}
