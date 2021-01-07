using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    public class AnimeReccViewModel
    {
        public AnimeReccViewModel()
        {
            this.Animes = new List<AnimeInListViewModel>();
        }
        public List<AnimeInListViewModel> Animes { get; set; }
    }
}
