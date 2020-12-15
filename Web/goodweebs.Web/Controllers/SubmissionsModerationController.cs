using GoodWeebs.Services.Data.GoodWeebsDataServices.SubmissionsServices;
using GoodWeebs.Web.Controllers;
using GoodWeebs.Web.ViewModels.SubmissionModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goodweebs.Web.Controllers
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
            return this.View(model);
        }

        [HttpPost]
        public IActionResult ViewAndEditAnimeSubmissions()
        {

        }
        public IActionResult ViewAndEditAnimeSubmission()
        {
            return this.View();
        }
        public IActionResult ViewAndEditAnimeSubmission()
        {
            return this.View();
        }
    }
}
