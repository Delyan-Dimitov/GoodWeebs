using GoodWeebs.Web.ViewModels.MangaViewModels;
using System.Collections.Generic;

namespace GoodWeebs.Web.ViewModels.MangaViewModels
{
    public class MangaInfoViewModel
    {
        public MangaViewModel Manga { get; set; }

        public IEnumerable<MangaViewModel> SimilarAnime { get; set; }
    }
}
