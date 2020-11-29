namespace GoodWeebs.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using GoodWeebs.Services;
    using GoodWeebs.Web.ViewModels;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IAnimeService animeService;

        public HomeController(IAnimeService animeService)
        {
            this.animeService = animeService;
        }

        public async Task<IActionResult> HomeLoggedOut()
        {
            var topAnimes = await this.animeService.GetTopGlobalAsync(4);
            HomeAnimeViewModel model = new HomeAnimeViewModel { TopAnimes = topAnimes };

            return this.View(model);
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
