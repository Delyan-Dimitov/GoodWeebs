namespace GoodWeebs.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using GoodWeebs.Services;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AnimeController : BaseController
    {
        private readonly IAnimeService animeService;
        private readonly UserManager<ApplicationUser> userManager;

        public AnimeController(IAnimeService animeService, UserManager<ApplicationUser> userManager)
        {
            this.animeService = animeService;
            this.userManager = userManager;
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
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var anime = this.animeService.GetById(id);
            var similar = this.animeService.GetSimilar(id, 3);
            var model = new AnimeInfoViewModel { Anime = anime, SimilarAnime = similar };
            model.ProfileId = myId;
            model.AnimeId = id;
            return this.View(model);
        }
    }
}
