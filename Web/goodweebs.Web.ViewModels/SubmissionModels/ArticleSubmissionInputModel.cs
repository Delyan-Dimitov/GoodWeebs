namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
{
    using System.ComponentModel.DataAnnotations;

    public class ArticleSubmissionInputModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(100)]
        [MaxLength(10000)]
        public string Content { get; set; }

        public int DbId { get; set; }

        public string SubmitterId { get; set; }
    }
}
