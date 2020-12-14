namespace Goodweebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using Entities;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReccomendationsService
    {
        Task<AnimeViewModel> FindRecomenations(string userId);

        //Task<string[]> GetTopGenres(string userId);

        Task<Dictionary<Anime, int>> GetTopGenreMatches(Dictionary<Anime, int> vaguelySimilar);

        Dictionary<Anime, int> MatchStudio(Dictionary<Anime, int> vaguelySimilar);

        Dictionary<Anime, int> AiringCoeficientMatch(Dictionary<Anime, int> vaguelySimilar);

        Dictionary<Anime, int> MatchRating(Dictionary<Anime, int> vaguelySimialar);

        Dictionary<Anime, int> MatchType(Dictionary<Anime, int> vaguelySimilar);

        Dictionary<Anime, int> EpisodeCoeficientMatch(Dictionary<Anime, int> vaguelySimilar);



    }
}
