namespace GoodWeebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Entities;
    using Entities.Maps;
    using global::GoodWeebs.Data;
    using global::GoodWeebs.Data.Common.Repositories;
    using global::GoodWeebs.Data.Models;
    using global::GoodWeebs.Data.Models.MappingTables;
    using global::GoodWeebs.Web.ViewModels.AnimeViewModels;
    using Microsoft.AspNetCore.Identity;

    public class AnimeReccomendationService : IAnimeReccomendationsService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDeletableEntityRepository<Anime> animeRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<UserGenre> userGenreRepo;
        private readonly IDeletableEntityRepository<WatchedMap> watchedMapsRepo;

        public AnimeReccomendationService(ApplicationDbContext dbContext, IDeletableEntityRepository<Anime> animeRepo, UserManager<ApplicationUser> userManager, IRepository<UserGenre> userGenreRepo, IDeletableEntityRepository<WatchedMap> watchedMapsRepo)
        {
            this.dbContext = dbContext;
            this.animeRepo = animeRepo;
            this.userManager = userManager;
            this.userGenreRepo = userGenreRepo;
            this.watchedMapsRepo = watchedMapsRepo;
        }
        public bool CanUserGetReccomendations(string userId)
        {
            var watchedMaps = this.watchedMapsRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            if (watchedMaps.Count >= 10)
            {
                return true;
            }
            return false;
        }

        public List<AnimeInListViewModel> FindRecomenations(string userId)
        {
            var topGenres = this.GetTopGenres(userId);
            var vaguelySimilar = this.FindVaguelySimilar(topGenres);
            var leaderBoard = this.CreateLeaderBoard(vaguelySimilar);
            leaderBoard = this.ProcessPoints(leaderBoard, topGenres, userId);
           var sortedLeaderBoard =  leaderBoard.OrderByDescending(x => x.Value).ToDictionary(z=> z.Key, y => y.Value);
            if (sortedLeaderBoard.Count >= 5)
            {
                sortedLeaderBoard = sortedLeaderBoard.Take(5).ToDictionary(z => z.Key, y => y.Value);
            }
           
            var reccomendations = new List<AnimeInListViewModel>();
            foreach (var item in leaderBoard)
            {
                reccomendations.Add(new AnimeInListViewModel { Title = item.Key.Title, AnimeId = item.Key.Id, Genre = item.Key.Genres, PictureUrl = item.Key.Picture, Synopsis = item.Key.Synopsis });
            }

            return reccomendations;
        }

        private List<string> GetTopGenres(string userId)
        {
            var watchedMaps = this.watchedMapsRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            List<Anime> usersAnimes = new List<Anime>();
            foreach (var watchedMap in watchedMaps)
            {
                var anime = this.animeRepo.AllAsNoTracking().Where(x => x.Id == watchedMap.AnimeId).FirstOrDefault();
                usersAnimes.Add(anime);
            }
            Dictionary<string, int> topGenres = new Dictionary<string, int>();
            foreach (var anime in usersAnimes)
            {
                List<string> genres = anime.Genres.Split(", ").ToList();
                foreach (var genre in genres)
                {
                    if (topGenres.ContainsKey(genre))
                    {
                        var value = topGenres[genre];
                        topGenres.Remove(genre);
                        topGenres.Add(genre, value++);
                    }
                    else
                    {
                        topGenres.Add(genre, 0);
                    }

                }
            }
            return topGenres.OrderByDescending(x => x.Value).Take(5).Select(x => x.Key).ToList();
        }

        private List<Anime> FindVaguelySimilar(List<string> topGenres)
        {
            var vaguelySimilar = new List<Anime>();
            foreach (var genre in topGenres)
            {
                var animes = this.animeRepo.AllAsNoTracking()
                    .Where(x => x.Genres.ToUpper()
                    .Contains(genre.ToUpper()))
                    .ToList();
                if (animes != null)
                {
                    vaguelySimilar.AddRange(animes);
                }

            }

            return vaguelySimilar;
        }

        private Dictionary<Anime, int> CreateLeaderBoard(List<Anime> vaguelySimilar)
        {
            var leaderBoard = new Dictionary<Anime, int>();
            foreach (var item in vaguelySimilar)
            {
                leaderBoard.Add(item, 0);
            }
            return leaderBoard;
        }

        private Dictionary<Anime, int> ProcessPoints(Dictionary<Anime, int> leaderBoard, List<string> topGenres, string userId) // TODO cut the collection at some point to gain more performance
        {
            var watchedMaps = this.watchedMapsRepo.AllAsNoTracking().Where(x => x.UserId == userId).ToList();
            List<Anime> watchedAnime = new List<Anime>();
            foreach (var watchedMap in watchedMaps)
            {
                var anime = this.animeRepo.AllAsNoTracking().Where(x => x.Id == watchedMap.AnimeId).FirstOrDefault();
                watchedAnime.Add(anime);
            }

            leaderBoard = this.ComputeTopGenreMatches(leaderBoard, topGenres); // MAX - > 6
            leaderBoard = this.ComputeEpisodeCoeficientMatches(leaderBoard, watchedAnime); // MAX - 2/ total max - 11
            leaderBoard = this.MatchRating(leaderBoard, watchedAnime); // MAX - 1 / TOTAL AMX 12
            leaderBoard = this.MatchStudios(leaderBoard, watchedAnime); // MAX - 1/ TOTAL MAX 13
            leaderBoard = this.MatchType(leaderBoard, watchedAnime); // MAX - 1/ TOTAL MAX 13

            return leaderBoard;

        }

        // Gives a certain amount of points based on how many of the top genres are present in each of the vaguely similar anime and the position of said genre in the toplist
        private Dictionary<Anime, int> ComputeTopGenreMatches(Dictionary<Anime, int> leaderBoard, List<string> topGenres)
        {
            var updatedLeaderboard = new Dictionary<Anime, int>();
            foreach (var item in leaderBoard)
            {
                var value = item.Value;
                var key = item.Key;

                for (int i = 0; i < topGenres.Count - 1; i++)
                {
                    if (item.Key.Genres.ToUpper().Contains(topGenres[i].ToUpper()))   // 0 -> 3 ; 1 -> 2; 2 -> 1
                    {
                        value += topGenres.Count - i;
                    }
                }

                updatedLeaderboard.Add(key, value);
            }

            return updatedLeaderboard;

        }

        private Dictionary<Anime, int> ComputeEpisodeCoeficientMatches(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {
            var animeWithCoeficientSum = new Dictionary<Anime, int>();
            var updatedLaederboard = new Dictionary<Anime, int>();
            foreach (var item in leaderBoard)
            {
                updatedLaederboard.Add(item.Key, item.Value);
                var coeficientSum = 0;
                foreach (var anime in watchedAnime)
                {
                    coeficientSum += this.ComputeEpisodeCoeficient(item.Key, anime);
                }

                animeWithCoeficientSum.Add(item.Key, coeficientSum);
            }

            animeWithCoeficientSum.OrderByDescending(x => x.Value);
            var dictPointsBasedOnCoeficient = this.AssingPointsBasedOnEpisodeCoeficient(animeWithCoeficientSum);
            foreach (var item in dictPointsBasedOnCoeficient)
            {
                var key = item.Key;
                var value = item.Value;
                if (updatedLaederboard.ContainsKey(key))
                {
                    var leaderBoardValueAtKey = updatedLaederboard[key];
                    updatedLaederboard.Remove(key);
                    updatedLaederboard.Add(key, leaderBoardValueAtKey + value);
                }
            }

            return updatedLaederboard;
        }

        private int ComputeEpisodeCoeficient(Anime firstAnime, Anime secondAnime)
        {
            var coef = 0;
            if (int.TryParse(firstAnime.Episodes, out int result) && int.TryParse(firstAnime.Episodes, out int result2))
            {
                var firstEpCount = int.Parse(firstAnime.Episodes);
                var secondEpCount = int.Parse(secondAnime.Episodes);
                coef = Math.Abs(firstEpCount - secondEpCount);
            }

            return coef;
        } // TODO this can blowup like hiroshima

        private Dictionary<Anime, int> AssingPointsBasedOnEpisodeCoeficient(Dictionary<Anime, int> animeWithCoeficientSum)
        {
            var dictWithFinalPoints = new Dictionary<Anime, int>();
            var topMatches = animeWithCoeficientSum.Take(3);
            var secondaryMatches = animeWithCoeficientSum.Skip(3).Take(3);
            foreach (var item in topMatches)
            {
                dictWithFinalPoints.Add(item.Key, 2);
            }
            foreach (var item in secondaryMatches)
            {
                dictWithFinalPoints.Add(item.Key, 1);
            }
            return dictWithFinalPoints;
        }

        private Dictionary<Anime, int> MatchRating(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {
            var updatedLeaderBoard = new Dictionary<Anime, int>();
            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;
                updatedLeaderBoard.Add(key, value);
                var counter = 0;
                foreach (var anime in watchedAnime)
                {
                    if (item.Key.Rating != null)
                    {
                        if (item.Key.Rating.ToUpper() == anime.Rating.ToUpper())
                        {
                            counter++;
                        }
                    }

                }

                if (counter > 0)
                {
                    updatedLeaderBoard.Remove(key);
                    updatedLeaderBoard.Add(key, value + 1);
                }
            }

            return updatedLeaderBoard;
        }

        private Dictionary<Anime, int> MatchStudios(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {
            var watchedAnimeStudios = new StringBuilder();
            watchedAnime.ForEach(x => watchedAnimeStudios.Append(x.Studios.ToUpper()));
            var studiosAsArray = watchedAnimeStudios.ToString().Split(",").Distinct().ToArray();
            var updatedLeaderBoard = new Dictionary<Anime, int>();
            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;
                updatedLeaderBoard.Add(key, value);
                if (studiosAsArray.Contains(item.Key.Studios.Split(",")[0].ToUpper())) // TODO this is pretty scuffed ngl literally the ugliest code i have written
                {
                    updatedLeaderBoard.Remove(key);
                    updatedLeaderBoard.Add(key, value + 1);
                }
            }

            return updatedLeaderBoard;
        }

        private Dictionary<Anime, int> MatchType(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {

            var updatedLeaderBoard = new Dictionary<Anime, int>();

            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;
                updatedLeaderBoard.Add(key, value);

                foreach (var anime in watchedAnime)
                {
                    if (anime.Type.ToUpper().Contains(item.Key.Type.ToUpper()))
                    {
                        updatedLeaderBoard.Remove(key);
                        updatedLeaderBoard.Add(key, value + 1);
                        break;
                    }
                }
            }
            return updatedLeaderBoard;
        }
    }
}
