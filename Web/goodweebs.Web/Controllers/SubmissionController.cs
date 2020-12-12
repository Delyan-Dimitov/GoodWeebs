namespace GoodWeebs.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.GoodWeebs.Services.SubmissionsServices;
    using GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize]
    public class SubmissionController : BaseController
    {
        private readonly ISubmissionsService subService;
        private readonly UserManager<ApplicationUser> userManager;

        public SubmissionController(ISubmissionsService subService, UserManager<ApplicationUser> userManager)
        {
            this.subService = subService;
            this.userManager = userManager;
        }

        // anime
        public IActionResult SubmitAnime()
        {
            return this.View();
        }

        public IActionResult SubmitAnimeWithUrl()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnimeWithUrlAsync(string url)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.subService.SubmitAnimeWithUrlAsync(url, userId);
            return this.Redirect("Home/Index");
        }

        public IActionResult SubmitAnimeFull()
        {
            ////var group1 = new SelectListGroup() { Name = "group1"};

            AnimeSubmissionInputModel model = new AnimeSubmissionInputModel();
            ////this.ViewBag.Genres = new List<SelectListItem>()
            ////{
            ////    new SelectListItem() {Text = "Action", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Aventure", Value = "1", Group = group1},
            ////    new SelectListItem() {Text = "Cars", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Demons", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Ecchi", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Drama", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Fantasy", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Hentai", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Historical", Value = "1", Group = group1 },
            ////    new SelectListItem() {Text = "Horror", Value = "1", Group = group1 },
            ////};



            //{
            //    Genres = new List<string>
            //    {
            //        "Action", "Aventure", "Cars", "Comedy", "Demons", "Drama", "Ecchi","Fantasy", "Harem", "Hentai", "Historical", "Horror", "Kids", "Magic", "Martial Arts", "Mecha", "Music", "Mystery", "Parody", "Police", "Romance", "Samurai", "School", "Sci-Fi", "Shoujo", "Shoujo Ai", "Shounen", "Shounen Ai", "Space", "Sports", "Super Power", "Supernatural", "Vampire", "Yaoi", "Yuri",
            //    },

            //    Rating = new List<string>
            //    {
            //        "TV", "OVA", "Movie", "Special",
            //    },

            //    Status = new List<string>
            //    {
            //        "Currently Airing" , "Finished Airing",
            //    },
            //};
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAnimeFullAsync(AnimeSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.subService.SubmitAnimeFullAsync(model, userId, "Full");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.RedirectToAction("Home/HomeUserLoggedOut");
        }

        // manga
        public IActionResult SubmitManga()
        {
            return this.View();
        }

        public IActionResult SubmitMangaWithUrl()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMangaWithUrlAsync(string url)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.subService.SubmitMangaWithUrlAsync(url, userId);
            return this.Redirect("Home/Index");
        }

        public IActionResult SubmitMangaFull()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMangaFullAsync(MangaSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            try
            {
                await this.subService.SubmitMangaFullAsync(model, userId, "Full");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(model);
            }

            return this.Redirect("Home/Index");
        }

        // aritcle

        public IActionResult SubmitArticle()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SubmitArticle(string url)
        {
            return this.Redirect("Home/Index");
        }
    }
}
