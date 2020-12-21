namespace GoodWeebs.Web.Controllers
{
    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using GoodwWebs.Services.Data.GoodWeebsDataServices.ShelvesServices;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ShelvesConroller : BaseController
    {
        private readonly IAnimeShelfService animeShelfService;
        private readonly IMangaShelfService mangaShelfService;
        private readonly UserManager<ApplicationUser> userManager;

        public ShelvesConroller(
            IAnimeShelfService animeShelfService,
            IMangaShelfService mangaShelfService,
            UserManager<ApplicationUser> userManager)
        {
            this.animeShelfService = animeShelfService;
            this.mangaShelfService = mangaShelfService;
            this.userManager = userManager;
        }

        //public Task<IActionResult> Watched(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

        //public Task<IActionResult> Watching(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

        //public Task<IActionResult> WantToWatch(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

        //public Task<IActionResult> Read(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

        //public Task<IActionResult> Reading(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

        //public Task<IActionResult> WantToRead(string userId)
        //{
        //    var model = null;
        //    return this.View(model);
        //}

    }
}
