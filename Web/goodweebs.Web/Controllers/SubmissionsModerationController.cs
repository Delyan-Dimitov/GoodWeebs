namespace GoodWeebs.Web.Controllers
{
    using System.Threading.Tasks;

    using GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices;
    using GoodWeebs.Web.ViewModels.SubmissionInputModels;
    using GoodWeebs.Web.ViewModels.SubmissionModels;
    using Microsoft.AspNetCore.Mvc;

    public class SubmissionsModerationController : BaseController
    {
        private readonly ISubmissionsService subService;

        public SubmissionsModerationController(ISubmissionsService subService)
        {
            this.subService = subService;
        }

        public IActionResult All(int id = 1)
        {
            var model = new SubmissionListViewModel
            {
                Page = id,
                Submissions = this.subService.GetAll(id, 1),
                SubmissionsCount = this.subService.GetCount(),
                SubmissionsPerPage = 1,
            };

            return this.View(model);
        }

        public IActionResult ViewAndEditAnimeSubmission(int id)
        {
            var model = this.subService.GetAnimeSubmission(id);
            model.DbId = id;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ViewAndEditAnimeSubmission(AnimeSubmissionInputModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.subService.ApproveAnimeSubmission(model);

            await this.subService.RemoveSubmission(id, "Anime", "Approved");
            return this.RedirectToAction("All");
        }

        public async Task<IActionResult> RejectAnimeSubmission(int id)
        {
            await this.subService.RemoveSubmission(id, "Anime", "Rejected");
            return this.RedirectToAction("All");
        }

        public IActionResult ViewAndEditMangaSubmission(int id)
        {
            var model = this.subService.GetMangaSubmission(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ViewAndEditMangaSubmission(MangaSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.subService.ApproveMangaSubmission(model);

            await this.subService.RemoveSubmission(model.DbId, "Manga", "Approved");
            return this.RedirectToAction("AllSubmissions");
        }

        public async Task<IActionResult> RejectMangaSubmission(int id)
        {
            await this.subService.RemoveSubmission(id, "Manga", "Rejected");
            return this.RedirectToAction("All");
        }

        public IActionResult ViewAndEditArticleSubmission(int id)
        {
            var model = this.subService.GetArticleSubmission(id);
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAndSubmitArticleSubmissions(ArticleSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.subService.ApproveArticleSubmission(model);

            await this.subService.RemoveSubmission(model.DbId, "Manga", "Approved");
            return this.RedirectToAction("AllSubmissions");
        }
    }
}
