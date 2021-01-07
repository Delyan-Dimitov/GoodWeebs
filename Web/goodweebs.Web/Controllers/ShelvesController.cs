namespace GoodWeebs.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.UpdatesServices;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ShelvesController : BaseController
    {
        private readonly IAnimeShelfService animeShelfService;
        private readonly IMangaShelfService mangaShelfService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUpdateService updateService;

        public ShelvesController(
            IAnimeShelfService animeShelfService,
            IMangaShelfService mangaShelfService,
            UserManager<ApplicationUser> userManager,
            IUpdateService updateService)
        {
            this.animeShelfService = animeShelfService;
            this.mangaShelfService = mangaShelfService;
            this.userManager = userManager;
            this.updateService = updateService;
        }

        public async Task<IActionResult> Watched(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.animeShelfService.GetWatched(id);
            model.ProfileId = id;

            if (myId == id)
            {
                model.MyProfile = true;
            }

            return this.View(model);
        }

        public async Task<IActionResult> WatchingAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.animeShelfService.GetWatching(id);
            model.ProfileId = id;
            if (myId == id)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        public async Task<IActionResult> WantToWatchAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.animeShelfService.GetWantToWatch(id); // TODO rename
            model.ProfileId = id;
            if (myId == id)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        public async Task<IActionResult> ReadAsync(string id)
        {

            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetRead(id);
            model.ProfileId = id; 
            if (myId == id)
            {
                model.MyProfile = true;
            }

            return this.View(model);
        }

        public async Task<IActionResult> ReadingAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetReading(id);
            model.ProfileId = id;
            if (myId == id)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }

        public async Task<IActionResult> WantToReadAsync(string id)
        {
            var myId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = await this.mangaShelfService.GetWantToRead(id);
            model.ProfileId = id;
            if (myId == id)
            {
                model.MyProfile = true;
            }
            return this.View(model);
        }


        public async Task<IActionResult> AddToRead(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.mangaShelfService.AddToRead(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 2, "Read");
            }
            return this.RedirectToAction("Read", new { id = userId });
        }

        public async Task<IActionResult> AddToReading(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.mangaShelfService.AddToReading(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 2, "Reading");
            }
            return this.RedirectToAction("Reading", new { id = userId });
        }



        public async Task<IActionResult> AddToWantToRead(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.mangaShelfService.AddToWant(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 1, "WantToRead");
            }
            return this.RedirectToAction("WantToRead", new { id = userId });
        }

        public async Task<IActionResult> AddToWatched(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.animeShelfService.AddToWatched(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 1, "Watched");
            }

            return this.RedirectToAction("Watched", new { id = userId });
        }
        public async Task<IActionResult> AddToWatching(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.animeShelfService.AddToWatching(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 1, "Watching");
            }

            return this.RedirectToAction("Watching", new { id = userId });
        }

        public async Task<IActionResult> AddToWantToWatch(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var successfull = await this.animeShelfService.AddToWantToWatch(userId, id);
            if (successfull)
            {
                await this.updateService.CreateSeriesUpdate(userId, id, 1, "WantToWatch");
            }

            return this.RedirectToAction("WantToWatch", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromWatched(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWatched(userId, id);
            return this.RedirectToAction("Watched", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromWatching(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWatching(userId, id);
            return this.RedirectToAction("Watching", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromWantToWatch(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.animeShelfService.RemoveFromWant(userId, id);
            return this.RedirectToAction("WantToWatch", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromRead(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromRead(userId, id);
            return this.RedirectToAction("Read", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromReading(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromReading(userId, id);
            return this.RedirectToAction("Reading", new { id = userId });
        }

        public async Task<IActionResult> RemoveFromWantToRead(int id)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.mangaShelfService.RemoveFromWant(userId, id);
            return this.RedirectToAction("WantToRead", new { id = userId });

        }
    }

}