namespace GoodWeebs.Web.ViewModels.HomeViewModels
{

    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using GoodWeebs.Web.ViewModels.UpdateViewModels;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.AnimeReccomendations = new List<AnimeInListViewModel>();
        }
        public UpdateListViewModel Updates { get; set; }

        public List<AnimeInListViewModel> AnimeReccomendations { get; set; }
    }
}
