namespace GoodWeebs.Web.ViewModels.SubmissionModels
{
    using System;

    public class SubmissionInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SubmissionType { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
