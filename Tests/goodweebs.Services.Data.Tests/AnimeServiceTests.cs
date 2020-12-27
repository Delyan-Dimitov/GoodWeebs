using Entities;
using Entities.Maps;
using GoodWeebs.Data;
using GoodWeebs.Data.Common.Repositories;
using GoodWeebs.Data.Models;
using GoodWeebs.Services.GoodWeebs.Services.AnimeServices;
using GoodWeebs.Web.ViewModels.AnimeViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GoodWeebs.Services.Data.Tests
{
    public class AnimeServiceTests
    {
        [Fact]
        public async Task GetAllReturnsAllAnimeCorrectly()
        {
            // Arrange

            var animeList = new List<Anime>();
            var mockAnimeRepo = new Mock<IDeletableEntityRepository<Anime>>();
            mockAnimeRepo.Setup(x => x.AllAsNoTracking()).Returns(animeList.AsQueryable());
            mockAnimeRepo.Setup(x => x.AddAsync(It.IsAny<Anime>())).Callback(
                (Anime anime) => animeList.Add(anime));

            var watchedList = new List<WatchedMap>();
            var mockWatchedAnimeRepo = new Mock<IDeletableEntityRepository<WatchedMap>>();
            mockWatchedAnimeRepo.Setup(x => x.All()).Returns(watchedList.AsQueryable());
            mockWatchedAnimeRepo.Setup(x => x.AddAsync(It.IsAny<WatchedMap>())).Callback(
                (WatchedMap watchedMap) => watchedList.Add(watchedMap));

            var guid = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(guid)
                .Options;

            var db = new ApplicationDbContext(options);

            var animeService = new AnimeService(mockAnimeRepo.Object, mockWatchedAnimeRepo.Object, db);

            // Act
            var anime = new Anime { Id = 1, Title = "Naruto", Synopsis = "ala bala" }; //
            var anime2 = new Anime { Id = 2, Title = "Bleach", Synopsis = "ala bala" }; //
            var anime3 = new Anime { Id = 4, Title = "DBZ", Synopsis = "ala bala" }; //
            var anime12 = new Anime { Id = 5, Title = "DBZ", Synopsis = "ala bala" }; //
            var anime4 = new Anime { Id = 6, Title = "DBZ", Synopsis = "ala bala" }; //
            var anime6 = new Anime { Id = 7, Title = "DBZ", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            var anime7 = new Anime { Id = 8, Title = "Drugo", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            var anime8 = new Anime { Id = 9, Title = "peto", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            var anime9 = new Anime { Id = 10, Title = "shesto", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            var anime10 = new Anime { Id = 11, Title = "DBZ", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            var anime11 = new Anime { Id = 12, Title = "DBZ", Synopsis = "ala bala", Picture = "neshto", Genres = "neshto" };
            animeList.Add(anime);
            animeList.Add(anime2);
            animeList.Add(anime3);
            animeList.Add(anime4);
            animeList.Add(anime6);
            animeList.Add(anime7);
            animeList.Add(anime8);
            animeList.Add(anime9);
            animeList.Add(anime10);
            animeList.Add(anime11);
            animeList.Add(anime12);

            var animeViewModels = animeService.GetAll(2, 5);
            List<AnimeInListViewModel> listViewModels = new List<AnimeInListViewModel>();
            listViewModels.Add(new AnimeInListViewModel { AnimeId = 7,  Title = "DBZ", Synopsis = "ala bala", PictureUrl = "neshto", Genre = "neshto" });
            listViewModels.Add(new AnimeInListViewModel { AnimeId = 8, Title = "Drugo", Synopsis = "ala bala", PictureUrl = "neshto", Genre = "neshto" });
            listViewModels.Add(new AnimeInListViewModel { AnimeId = 9, Title = "peto", Synopsis = "ala bala", PictureUrl = "neshto", Genre = "neshto" });
            listViewModels.Add(new AnimeInListViewModel { AnimeId = 10, Title = "shesto", Synopsis = "ala bala", PictureUrl = "neshto", Genre = "neshto" });
            listViewModels.Add(new AnimeInListViewModel { AnimeId = 11, Title = "DBZ", Synopsis = "ala bala", PictureUrl = "neshto", Genre = "neshto", });

            var first = string.Join(", ", listViewModels);
            var second = string.Join(", ", animeViewModels);
            Assert.Equal( first, second);
        }

        [Fact]
        public async Task GetTopgGlobalShouldReturnCorrectAnime()
        {
            var animeList = new List<Anime>();
            var mockAnimeRepo = new Mock<IDeletableEntityRepository<Anime>>();
            mockAnimeRepo.Setup(x => x.AllAsNoTracking()).Returns(animeList.AsQueryable());
            mockAnimeRepo.Setup(x => x.AddAsync(It.IsAny<Anime>())).Callback(
                (Anime anime) => animeList.Add(anime));

            var watchedList = new List<WatchedMap>();
            var mockWatchedAnimeRepo = new Mock<IDeletableEntityRepository<WatchedMap>>();
            mockWatchedAnimeRepo.Setup(x => x.All()).Returns(watchedList.AsQueryable());
            mockWatchedAnimeRepo.Setup(x => x.AddAsync(It.IsAny<WatchedMap>())).Callback(
                (WatchedMap watchedMap) => watchedList.Add(watchedMap));

            var guid = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(guid)
                .Options;

            var db = new ApplicationDbContext(options);

            var animeService = new AnimeService(mockAnimeRepo.Object, mockWatchedAnimeRepo.Object, db);

            // act
            var anime5 = new Anime { Id = 12, Title = "DBZ", Synopsis = "ala bala" };
            var anime13 = new Anime { Id = 12, Title = "DBZ", Synopsis = "ala bala" };

            db.Animes.Add(anime5);
            db.SaveChanges();
            db.Animes.Add(anime13);
            db.SaveChanges();

            var user = new ApplicationUser { Id = "neshto" };
            var user2 = new ApplicationUser { Id = "neshto2" };
           
            db.Users.Add(user);
            db.SaveChanges();
            db.Users.Add(user2);
            db.SaveChanges();

            var watchedMap = new WatchedMap { AnimeId = anime5.Id, UserId = user.Id };
            var watchedMap2 = new WatchedMap { AnimeId = anime13.Id, UserId = user2.Id };

            db.WatchedMaps.Add(watchedMap);
            db.SaveChanges();
            db.WatchedMaps.Add(watchedMap2);
            db.SaveChanges();

            var topAnime = await animeService.GetTopGlobalAsync(2);
            var topAnimeList = new List<Anime> { anime5, anime13 };

            var topAnimeString = string.Join(", ", topAnime);
            var topAnimeListString = string.Join(", ", topAnimeList);

            Assert.Equal(topAnimeListString, topAnimeString);

        }
    }
}
