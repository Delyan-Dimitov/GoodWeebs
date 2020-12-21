namespace GoodWeebs.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ShelvesController : BaseController
    {
        private readonly IAnimeShelfService animeShelfService;
        private readonly IMangaShelfService mangaShelfService;
        private readonly UserManager<ApplicationUser> userManager;

        public ShelvesController(
            IAnimeShelfService animeShelfService,
            IMangaShelfService mangaShelfService,
            UserManager<ApplicationUser> userManager)
        {
            this.animeShelfService = animeShelfService;
            this.mangaShelfService = mangaShelfService;
            this.userManager = userManager;
        }
        [Route("Shelves/Watched/{userId}")]
        public async Task<IActionResult> Watched(string userId)
        {
            var model = await this.animeShelfService.GetWatched(userId);

            return this.View(model);
        }

        public IActionResult Watching(string userId)
        {
            var model = this.animeShelfService.GetWatching(userId);
            return this.View(model);
        }

        public IActionResult WantToWatch(string userId)
        {
            var model = this.animeShelfService.GetWantToWatch(userId); // TODO rename
            return this.View(model);
        }

        public IActionResult Read(string userId)
        {
            var model = this.mangaShelfService.GetRead(userId);
            return this.View(model);
        }

        public IActionResult Reading(string userId)
        {
            var model = this.mangaShelfService.GetReading(userId);
            return this.View(model);
        }

        public IActionResult WantToRead(string userId)
        {
            var model = this.mangaShelfService.GetWantToRead(userId);
            return this.View(model);
        }

        public async Task<IActionResult> AddToRead(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToRead(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

        public async Task<IActionResult> AddToReading(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToReading(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

        public async Task<IActionResult> AddToWantToRead(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToWant(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

        [Route("Shelves/AddToWatched/{animeId}")]
        public async Task<IActionResult> AddToWatched(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWatched(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

        public async Task<IActionResult> AddToWatching(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWatching(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

        public async Task<IActionResult> AddToWantToWatch(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWantToWatch(userId, animeId);
            return this.Redirect(this.Request.Path.ToString());
        }

    }
}
