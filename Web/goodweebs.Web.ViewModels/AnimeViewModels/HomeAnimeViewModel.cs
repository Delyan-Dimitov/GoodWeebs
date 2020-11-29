using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    public class HomeAnimeViewModel
    {
        public IEnumerable<Anime> TopAnimes { get; set; }
        //public IEnumerable<Article> TopArticles { get; set; }
    }
}
