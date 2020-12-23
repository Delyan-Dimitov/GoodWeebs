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
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.animeShelfService.GetWatched(userId);
            model.ProfileId = userId;

            if (myId == userId)
            {
                model.MyProfile = true;
            }

            return this.View(model);
        }

        [Route("Shelves/Watching/{userId}")]
        public async Task<IActionResult> WatchingAsync(string userId)
        {
            var model = await this.animeShelfService.GetWatching(userId);
            model.ProfileId = userId;
            return this.View(model);
        }

        [Route("Shelves/WantToWatch/{userId}")]
        public async Task<IActionResult> WantToWatchAsync(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.animeShelfService.GetWantToWatch(userId); // TODO rename
            model.ProfileId = userId;
            if (myId == userId)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        [Route("Shelves/Read/{userId}")]
        public async Task<IActionResult> ReadAsync(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetRead(userId);
            if (myId == userId)
            {
                model.MyProfile = true;
            }

            return this.View(model);
        }

        [Route("Shelves/Reading/{userId}")]
        public async Task<IActionResult> ReadingAsync(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetReading(userId);
            if (myId == userId)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        [Route("Shelves/WantToRead/{userId}")]
        public async Task<IActionResult> WantToReadAsync(string userId)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetWantToRead(userId);
            if (myId == userId)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }


        [Route("Shelves/AddToRead/{mangaId}")]
        public async Task<IActionResult> AddToRead(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToRead(userId, animeId);
            return this.RedirectToAction("Read/{userId}");
        }

        [Route("Shelves/AddToReading/{mangaId}")]
        public async Task<IActionResult> AddToReading(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToReading(userId, animeId);
            return this.RedirectToAction("Reading/{userId}");
        }


        [Route("Shelves/AddToWantToRead/{animeId}")]

        public async Task<IActionResult> AddToWantToRead(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.AddToWant(userId, animeId);
            return this.RedirectToAction("WantToRead/{userId}");
        }

        [Route("Shelves/AddToWatched/{animeId}")]
        public async Task<IActionResult> AddToWatched(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWatched(userId, animeId);
            return this.RedirectToAction("Watched", new { id = userId });
        }

        [Route("Shelves/AddToWatching/{animeId}")]
        public async Task<IActionResult> AddToWatching(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWatching(userId, animeId);
            return this.RedirectToAction("Watching", new { id = userId });
        }

        [Route("Shelves/AddToWantToWatch/{mangaId}")]
        public async Task<IActionResult> AddToWantToWatch(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.AddToWantToWatch(userId, animeId);
            return this.RedirectToAction("WantToWatch", new { id = userId });
        }

        [Route("Shelves/RemoveFromWatched/{animeId}")]
        public async Task<IActionResult> RemoveFromWatched(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWatched(userId, animeId);
            return this.RedirectToAction("Watched", new { id = userId });
        }

        [Route("Shelves/RemoveFromWatching/{animeId}")]
        public async Task<IActionResult> RemoveFromWatching(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWatching(userId, animeId);
            return this.RedirectToAction("Watching", new { id = userId });
        }

        [Route("Shelves/RemoveFromWantToWatch/{animeId}")]
        public async Task<IActionResult> RemoveFromWantToWatch(int animeId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWant(userId, animeId);
            return this.RedirectToAction("WantToWatch", new { id = userId });
        }

        [Route("Shelves/RemoveFromRead/{mangaId}")]
        public async Task<IActionResult> RemoveFromRead(int mangaId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromRead(userId, mangaId);
            return this.RedirectToAction("Read", new { id = userId });
        }

        [Route("Shelves/RemoveFromReading/{mangaId}")]
        public async Task<IActionResult> RemoveFromReading(int mangaId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromReading(userId, mangaId);
            return this.RedirectToAction("Reading/{userId}");
        }

        [Route("Shelves/RemoveFromWantRead/{animeId}")]
        public async Task<IActionResult> RemoveFromWantToRead(int mangaId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromWant(userId, mangaId);
            return this.RedirectToAction("WantToRead", new { id = userId });

        }
    }

}