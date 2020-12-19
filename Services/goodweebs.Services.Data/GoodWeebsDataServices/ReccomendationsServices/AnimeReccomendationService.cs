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

        public async Task<AnimeViewModel> FindRecomenationsAsync(string userId)
        {
            var topGenres = this.GetTopGenres(userId);
            var vaguelySimilar = this.FindVaguelySimilar(topGenres);
            var leaderBoard = this.CreateLeaderBoard(vaguelySimilar);
            leaderBoard = await this.ProcessPoints(leaderBoard, topGenres);

            return new AnimeViewModel();
        }

        private List<string> GetTopGenres(string userId)
        {
            var topGenres = this.userGenreRepo.AllAsNoTracking()
                .Where(x => x.Count != 0)
                .OrderByDescending(x => x.Count)
                .Take(3).Select(x => x.Genre)
                .ToList();

            return topGenres;
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

                vaguelySimilar.AddRange(animes);
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

        private async Task<Dictionary<Anime, int>> ProcessPoints(Dictionary<Anime, int> leaderBoard, List<string> topGenres) // TODO cut the collection at some point to gain more performance
        {
            var watchedAnime = this.watchedMapsRepo.AllAsNoTracking().Select(x => x.Anime).ToList();
            leaderBoard = this.ComputeTopGenreMatches(leaderBoard, topGenres); // MAX - > 6
            leaderBoard = this.ComputeAiringCoeficientMatches(leaderBoard, watchedAnime); // MAX - 3 / total max - 9
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

        private Dictionary<Anime, int> ComputeAiringCoeficientMatches(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {
            var animeWithCoeficientSum = new Dictionary<Anime, int>();
            var updatedLaederboard = leaderBoard;
            foreach (var item in leaderBoard)
            {
                var coeficientSum = 0;
                foreach (var anime in watchedAnime)
                {
                    coeficientSum += this.ComputeAiringCoeficient(item.Key, anime);
                }

                animeWithCoeficientSum.Add(item.Key, coeficientSum);
            }

            animeWithCoeficientSum.OrderBy(x => x.Value);
            var dictPointsBasedOnCoeficient = this.AssingPointsBasedOnAiringCoeficient(animeWithCoeficientSum);
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

        private int ComputeAiringCoeficient(Anime firstAnime, Anime secondAnime)
        {
            var firstAnimeAsArray = firstAnime.Aired.Split(" ").ToArray();
            var secondAnimeAsArray = secondAnime.Aired.Split(" ").ToArray();

            var coeficient =
                Math.Abs(int.Parse(firstAnimeAsArray[0]) - int.Parse(secondAnimeAsArray[0])) +
                Math.Abs(int.Parse(firstAnimeAsArray[2]) - int.Parse(secondAnimeAsArray[2]));
            return coeficient;
        }

        private Dictionary<Anime, int> AssingPointsBasedOnAiringCoeficient(Dictionary<Anime, int> animeWithCoeficientSum)
        {
            var dictWithFinalPoints = new Dictionary<Anime, int>();
            var TopMatches = animeWithCoeficientSum.Take(3);
            var SecondaryMatches = animeWithCoeficientSum.Skip(3).Take(3);
            var TertiaryMatches = animeWithCoeficientSum.Skip(6).Take(3);
            foreach (var item in TopMatches)
            {
                dictWithFinalPoints.Add(item.Key, 3);
            }
            foreach (var item in SecondaryMatches)
            {
                dictWithFinalPoints.Add(item.Key, 2);
            }
            foreach (var item in TertiaryMatches)
            {
                dictWithFinalPoints.Add(item.Key, 1);
            }
            return dictWithFinalPoints;
        }

        private Dictionary<Anime, int> ComputeEpisodeCoeficientMatches(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {
            var animeWithCoeficientSum = new Dictionary<Anime, int>();
            var updatedLaederboard = leaderBoard;
            foreach (var item in leaderBoard)
            {
                var coeficientSum = 0;
                foreach (var anime in watchedAnime)
                {
                    coeficientSum += this.ComputeEpisodeCoeficient(item.Key, anime);
                }

                animeWithCoeficientSum.Add(item.Key, coeficientSum);
            }

            animeWithCoeficientSum.OrderBy(x => x.Value);
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

        private int ComputeEpisodeCoeficient(Anime firstAnime, Anime secondAnime) => Math.Abs(int.Parse(firstAnime.Episodes) - int.Parse(secondAnime.Episodes)); // TODO this can blowup like hiroshima

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
            var updatedLeaderBoard = leaderBoard;
            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;

                var counter = 0;
                foreach (var anime in watchedAnime)
                {
                    if (item.Key.Rating.ToUpper() == anime.Rating.ToUpper())
                    {
                        counter++;
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
            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;
                if (studiosAsArray.Contains(item.Key.Studios.Split(",")[0].ToUpper())) // TODO this is pretty scuffed ngl literally the ugliest code i have written
                {
                    leaderBoard.Remove(key);
                    leaderBoard.Add(key, value + 1);
                }
            }

            return leaderBoard;
        }

        private Dictionary<Anime, int> MatchType(Dictionary<Anime, int> leaderBoard, List<Anime> watchedAnime)
        {


            foreach (var item in leaderBoard)
            {
                var key = item.Key;
                var value = item.Value;
                foreach (var anime  in watchedAnime)
                {
                    if (anime.Type.ToUpper().Contains(item.Key.Type.ToUpper()))
                    {
                        leaderBoard.Remove(key);
                        leaderBoard.Add(key, value + 1);
                        break;
                    }
                }
            }
            return leaderBoard;
        }
    }
}
