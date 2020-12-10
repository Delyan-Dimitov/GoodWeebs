namespace GoodwWebs.Web.Controllers
{
    using GoodWeebs.Services.GoodWeebs.Services.MangaServices;
    using GoodWeebs.Web.Controllers;
    using GoodWeebs.Web.ViewModels.MangaViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class MangaController : BaseController
    {
        private readonly IMangaService mangaService;

        public MangaController(IMangaService mangaService)
        {
            this.mangaService = mangaService;
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 12;
            var viewModel = new MangaListViewModel
            {
                Page = id,
                Mangas = this.mangaService.GetAll(id, ItemsPerPage),
                MangaCount = this.mangaService.GetCount(),
                MangaPerPage = ItemsPerPage,
            };
            return this.View(viewModel);
        }

        public IActionResult Info(int id)
        {
            var manga = this.mangaService.GetInfoById(id);
            var similar = this.mangaService.GetSimilar(id, 3);
            var model = new MangaInfoViewModel { Manga = manga, SimilarAnime = similar };
            return this.View(model);
        }
    }
}
