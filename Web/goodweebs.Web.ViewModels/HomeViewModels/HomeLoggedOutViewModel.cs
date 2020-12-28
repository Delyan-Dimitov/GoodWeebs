namespace GoodWeebs.Web.ViewModels.HomeViewModels
{
    using System.Collections.Generic;

    using Entities;
    using GoodWeebs.Web.ViewModels.AnimeViewModels;

    public class HomeLoggedOutViewModel
    {
        public HomeLoggedOutViewModel()
        {
            TopAnimes = new List<AnimeInListViewModel>();
        }
        public IEnumerable<AnimeInListViewModel> TopAnimes { get; set; } 

        // public IEnumerable<Article> TopArticles { get; set; }
    }
}
