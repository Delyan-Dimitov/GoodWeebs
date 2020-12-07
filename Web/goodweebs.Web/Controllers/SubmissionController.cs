﻿namespace GoodWeebs.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using goodweebs.Services.GoodWeebs.Services.SubmissionsServices;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
            await this.subService.SubmitAnimeAsync(new AnimeSubmissionInputModel() { SubmissionUrl = url }, userId, "Url");
            return this.Redirect("Home/Index");
        }

        public IActionResult SubmitAnimeFull()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SubmitAnimeFull(AnimeSubmissionInputModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            this.subService.SubmitAnimeAsync(model, userId, "Full");
            return this.Redirect("Home/Index");
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
        public IActionResult SubmitMangaWithUrl(string url)
        {
            return this.Redirect("Home/Index");
        }

        public IActionResult SubmitMangaFull()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SubmitMangaFull(AnimeSubmissionInputModel model)
        {
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
