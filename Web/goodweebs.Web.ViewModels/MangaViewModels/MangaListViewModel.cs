namespace GoodWeebs.Web.ViewModels.MangaViewModels
{
    using System;
    using System.Collections.Generic;

    public class MangaListViewModel
    {
        public IEnumerable<MangaInListViewModel> Mangas { get; set; }

        public int Page { get; set; }

        public int MangaCount { get; set; }

        public int MangaPerPage { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public bool HasNxtPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public int PreviousPage => this.Page - 1;

        public int PagesCount => (int)Math.Ceiling((double)this.MangaCount / this.MangaPerPage);
    }
}
