namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    using System.Collections.Generic;

    public class AnimeInfoViewModel
    {
        public string ProfileId { get; set; }

        public int AnimeId { get; set; }

        public AnimeViewModel Anime { get; set; }

        public IEnumerable<AnimeViewModel> SimilarAnime { get; set; }

    }
}
