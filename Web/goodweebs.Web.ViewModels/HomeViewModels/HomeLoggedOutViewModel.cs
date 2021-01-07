namespace GoodWeebs.Web.ViewModels.HomeViewModels
{
    using System.Collections.Generic;

    using Entities;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using GoodWeebs.Web.ViewModels.MangaViewModels;

    public class HomeLoggedOutViewModel
    {
        public HomeLoggedOutViewModel()
        {
            TopAnimes = new List<AnimeInListViewModel>();
            TopManga = new List<MangaInListViewModel>();
        }
        public IEnumerable<AnimeInListViewModel> TopAnimes { get; set; } 
        public IEnumerable<MangaInListViewModel> TopManga { get; set; } 

        // public IEnumerable<Article> TopArticles { get; set; }
    }
}
