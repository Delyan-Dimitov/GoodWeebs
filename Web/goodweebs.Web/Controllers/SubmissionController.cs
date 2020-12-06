namespace GoodWeebs.Web.Controllers
{
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
