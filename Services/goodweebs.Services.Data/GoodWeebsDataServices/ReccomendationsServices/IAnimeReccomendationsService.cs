namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using global::GoodWeebs.Web.ViewModels.AnimeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAnimeReccomendationsService
    {
        List<AnimeInListViewModel> FindRecomenations(string userId);

        bool CanUserGetReccomendations(string userId);
        //Task<string[]> GetTopGenres(string userId);

    }
}
