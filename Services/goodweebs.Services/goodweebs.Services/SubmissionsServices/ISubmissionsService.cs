using GoodWeebs.Data.Common.Repositories;
using GoodWeebs.Data.Models;
using GoodWeebs.Web.ViewModels.AnimeViewModels;
using GoodWeebs.Web.ViewModels.SubmissionInputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace goodweebs.Services.GoodWeebs.Services.SubmissionsServices
{
   public interface ISubmissionsService
    {
        Task SubmitAnimeAsync(AnimeSubmissionInputModel model, string userID, string submissionType);

        Task SubmitMangaAsync(MangaSubmissionInputModel model, string userID, string submissionType);

        Task SubmitArticleAsync(ArticleSubmissionInputModel model, string userID);
    }
}
