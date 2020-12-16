namespace GoodWeebs.Web.ViewModels.SubmissionModels
{
    using GoodWeebs.Web.ViewModels.SubmissionModels;
    using System;
    using System.Collections.Generic;

    public class SubmissionListViewModel
    {
        public SubmissionListViewModel()
        {
            this.Submissions = new List<SubmissionInListViewModel>();
        }

        public ICollection<SubmissionInListViewModel> Submissions { get; set; }

        public int Page { get; set; }

        public int SubmissionsCount { get; set; }

        public int SubmissionsPerPage { get; set; }

        public bool HasPreviousPage => this.Page > 1;

        public bool HasNxtPage => this.Page < this.PagesCount;

        public int NextPage => this.Page + 1;

        public int PreviousPage => this.Page - 1;

        public int PagesCount => (int)Math.Ceiling((double)this.SubmissionsCount / this.SubmissionsPerPage);
    }
}
