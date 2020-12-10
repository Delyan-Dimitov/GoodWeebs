namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    using System.Collections.Generic;

    public class AnimeInfoViewModel
    {
        public AnimeViewModel Anime { get; set; }

        public IEnumerable<AnimeViewModel> SimilarAnime { get; set; }

    }
}
