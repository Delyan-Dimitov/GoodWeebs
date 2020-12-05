namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    using System.Collections.Generic;

    using Entities;

    public class HomeAnimeViewModel
    {
        public IEnumerable<Anime> TopAnimes { get; set; } // TODO don't use anime as T

        // public IEnumerable<Article> TopArticles { get; set; }
    }
}
