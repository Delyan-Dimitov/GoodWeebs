using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    public class AnimeInfoViewModel
    {
        public AnimeViewModel Anime { get; set; }
        public IEnumerable<AnimeViewModel> SimilarAnime { get; set; }
    }
}
