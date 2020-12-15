namespace Goodweebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using Entities;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAnimeReccomendationsService
    {
        AnimeViewModel FindRecomenationsAsync(string userId);

        //Task<string[]> GetTopGenres(string userId);

   


    }
}
