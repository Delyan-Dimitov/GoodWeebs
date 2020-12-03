using goodweebs.Web.ViewModels.AnimeViewModels;
using GoodWeebs.Services;
using GoodWeebs.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goodweebs.Web.Controllers
{
    public class AnimeController : BaseController
    {
        private readonly IAnimeService animeService;

        public AnimeController(IAnimeService animeService)
        {
            this.animeService = animeService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPAge = 12;
            var viewModel = new AnimeListViewModel
            {
                Page = id,
                Animes = this.animeService.GetAll(id, ItemsPerPAge),
                AnimeCount = this.animeService.GetCount(),
                AnimePerPage = ItemsPerPAge,

            };
            return this.View(viewModel);
        }

        public IActionResult AnimeInfo(int id)
        {
            var anime = this.animeService.GetById(id);
            var similar = this.animeService.GetSimilar(id, 3);
            var model = new AnimeInfoViewModel { Anime = anime, SimilarAnime = similar };
         
            return this.View(model);
        }
    }
}
