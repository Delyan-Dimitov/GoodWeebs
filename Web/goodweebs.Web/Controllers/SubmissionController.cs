﻿namespace GoodWeebs.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using GoodWeebs.Data.Models;
    using GoodWeebs.Services.GoodWeebs.Services.SubmissionsServices;
    using GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using AngleSharp;
    using AngleSharp.Html;
    using Ganss.XSS;

    [Authorize]
    public class SubmissionController : BaseController
    {
        private readonly ICreateSubmissionsService subService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHtmlSanitizer htmlSanitizer;

        public SubmissionController(ICreateSubmissionsService subService, UserManager<ApplicationUser> userManager, IHtmlSanitizer htmlSanitizer)
        {
            this.subService = subService;
            this.userManager = userManager;
            this.htmlSanitizer = htmlSanitizer;
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
            return this.Redirect("SubmitAnime");
        }

        public IActionResult SubmitAnimeFull()
        {
            AnimeSubmissionInputModel model = new AnimeSubmissionInputModel();
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

            model.Synopsis = this.htmlSanitizer.Sanitize(model.Synopsis);

            await this.subService.SubmitAnimeFullAsync(model, userId, "Full");

            return this.Redirect("SubmitAnime");
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
            return this.Redirect("SubmitManga");
        }

        public IActionResult SubmitMangaFull()
        {
            var model = new MangaSubmissionInputModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitMangaFullAsync(MangaSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.Synopsis = this.htmlSanitizer.Sanitize(model.Synopsis);
            
            await this.subService.SubmitMangaFullAsync(model, userId, "Full");
          

            return this.Redirect("SubmitManga");
        }

        // aritcle
        public IActionResult SubmitArticle()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SubmitArticle(string url)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("Home/Index");
        }
    }
}
