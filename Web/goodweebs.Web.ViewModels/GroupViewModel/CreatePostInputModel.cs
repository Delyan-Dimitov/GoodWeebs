using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    public class CreatePostInputModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Post title too long!")]
        [MinLength(10, ErrorMessage = "Post title too short!")]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000, ErrorMessage = "Post too long!")]
        [MinLength(50, ErrorMessage = "Post too short!")]
        public string Content { get; set; }

        public string GroupId { get; set; }
    }
}
