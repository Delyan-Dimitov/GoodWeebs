namespace GoodWeebs.Web.ViewModels.AnimeViewModels
{
    using System;
    using System.Collections.Generic;

    public class AnimeListViewModel
    {
        public IEnumerable<AnimeInListViewModel> Animes { get; set; }

        public int Page { get; set; }

        public int AnimeCount { get; set; }

        public int AnimePerPage { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public bool HasNxtPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public int PreviousPage => this.Page - 1;

        public int PagesCount => (int)Math.Ceiling((double)this.AnimeCount / this.AnimePerPage);
    }
}
