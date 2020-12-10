namespace GoodWeebs.Web.ViewModels.MangaViewModels
{
    using System.Collections.Generic;

    public class MangaInfoViewModel
    {
        public MangaViewModel Manga { get; set; }

        public IEnumerable<MangaViewModel> SimilarManga { get; set; }
    }
}
