namespace Goodweebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using Entities;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReccomendationsService
    {
        AnimeViewModel FindRecomenations(string userId);

        //Task<string[]> GetTopGenres(string userId);

   


    }
}
