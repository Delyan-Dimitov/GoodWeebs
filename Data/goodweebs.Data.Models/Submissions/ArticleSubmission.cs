namespace Goodweebs.Data.Models.Submissions
{
    using System.ComponentModel.DataAnnotations;

    using GoodWeebs.Data.Models;

    public class ArticleSubmission
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser Submitter { get; set; }

        public string SubbmiterId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
