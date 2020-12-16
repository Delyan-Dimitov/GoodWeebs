using GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices;
using GoodWeebs.Web.Controllers;
using GoodWeebs.Web.ViewModels.SubmissionInputModels;
using GoodWeebs.Web.ViewModels.SubmissionModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodWeebs.Web.Controllers
{
    public class SubmissionsModerationController : BaseController
    {
        private readonly ISubmissionsService subService;

        public SubmissionsModerationController(ISubmissionsService subService)
        {
            this.subService = subService;
        }

        public IActionResult AllSubmissions(int id, int itemsPerPage)
        {
            var model = new SubmissionListViewModel
            {
                Page = id,
                Submissions = this.subService.GetAll(id, itemsPerPage),
                SubmissionsCount = this.subService.GetCount(),
                SubmissionsPerPage = itemsPerPage,
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
        public async Task<IActionResult> EditAndSubmitAnimeSubmissions(AnimeSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.subService.ApproveAnimeSubmission(model);

            await this.subService.UpdateUserSubmissionCount(model.SubmitterId);
            await this.subService.RemoveSubmission(model.DbId, "Anime", "Approved" );
            return this.RedirectToAction("AllSubmissions");
        }

        public IActionResult ViewAndEditMangaSubmission(int id)
        {
            var model = this.subService.GetMangaSubmission(id);
            model.DbId = id;
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAndSubmitMangaSubmissions(MangaSubmissionInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.subService.ApproveMangaSubmission(model);

            await this.subService.UpdateUserSubmissionCount(model.SubmitterId);
            await this.subService.RemoveSubmission(model.DbId, "Manga", "Approved");
            return this.RedirectToAction("AllSubmissions");
        }

        public IActionResult ViewAndEditArticleSubmission(int id)
        {
            var model = this.subService.GetArticleSubmission(id);
            model.DbId = id;
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

            await this.subService.UpdateUserSubmissionCount(model.SubmitterId);
            await this.subService.RemoveSubmission(model.DbId, "Manga", "Approved");
            return this.RedirectToAction("AllSubmissions");
        }
    }
}
