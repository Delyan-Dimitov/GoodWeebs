namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using global::GoodWeebs.Web.ViewModels.AnimeViewModels;
    using System.Threading.Tasks;

    public interface IAnimeReccomendationsService
    {
        Task<AnimeViewModel> FindRecomenationsAsync(string userId);

        //Task<string[]> GetTopGenres(string userId);

    }
}
