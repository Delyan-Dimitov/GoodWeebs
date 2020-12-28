namespace GoodWeebs.Web.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using GoodWeebs.Data.Models;
    using GoodWeebs.Services;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ReccomendationsServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices;
    using GoodWeebs.Web.ViewModels;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using GoodWeebs.Web.ViewModels.HomeViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IAnimeService animeService;
        private readonly IUpdateService updateService;
        private readonly IAnimeReccomendationsService animeReccomendationsService;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(
            IAnimeService animeService,
            IUpdateService updateService,
            IAnimeReccomendationsService animeReccomendationsService,
            UserManager<ApplicationUser> userManager)
        {
            this.animeService = animeService;
            this.updateService = updateService;
            this.animeReccomendationsService = animeReccomendationsService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> HomeLoggedOut()
        {
            var topAnimes = await this.animeService.GetTopGlobalAsync(6);
            HomeLoggedOutViewModel model = new HomeLoggedOutViewModel { TopAnimes = topAnimes };

            return this.View(model);
        }

        public async Task<IActionResult> IndexAsync()
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("HomeLoggedOut");
            }
            var model = new HomeViewModel();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (this.animeReccomendationsService.CanUserGetReccomendations(userId))
            {
               model.AnimeReccomendations = this.animeReccomendationsService.FindRecomenations(userId);
            }
            model.Updates = await this.updateService.GetRelevantUpdatesAsViewModelAsync(userId);
            return this.View(model);
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
