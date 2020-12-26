using System.ComponentModel.DataAnnotations;

namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    public class CommentInputModel
    {
        [Required]
        [MaxLength(5000, ErrorMessage = "Comment too long!")]
        [MinLength(10, ErrorMessage = "Comment too short!")]
        public string Content { get; set; }

        public string PostId { get; set; }
    }
}
