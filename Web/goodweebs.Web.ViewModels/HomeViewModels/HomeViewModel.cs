namespace GoodWeebs.Web.ViewModels.HomeViewModels
{

    using GoodWeebs.Web.ViewModels.AnimeViewModels;
    using GoodWeebs.Web.ViewModels.UpdateViewModels;

    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.AnimeReccomendations = new AnimeReccViewModel();
            this.Updates = new UpdateListViewModel();
        }
        public UpdateListViewModel Updates { get; set; }

        public AnimeReccViewModel AnimeReccomendations { get; set; }
    }
}
