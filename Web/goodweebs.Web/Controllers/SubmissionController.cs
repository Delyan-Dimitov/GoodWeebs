namespace Goodweebs.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GoodWeebs.Web.Controllers;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class SubmissionController : BaseController
    {
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
        public IActionResult SubmitAnimeWithUrl(string url)
        {
            return this.Redirect("Home/Index");
        }

        public IActionResult SubmitAnimeFull()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult SubmitAnimeFull(AnimeSubmissionInputModel model)
        {
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
    }
}
