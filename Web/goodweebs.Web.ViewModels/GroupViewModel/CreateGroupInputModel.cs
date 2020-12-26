namespace GoodWeebs.Web.ViewModels.GroupViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateGroupInputModel
    {
        [MaxLength(50, ErrorMessage = "Name too long!")]
        [MinLength(5, ErrorMessage = "Name not long enough!")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Description too long!")]
        [MinLength(30 , ErrorMessage = "Description too short!")]
        public string Description { get; set; }

        [Url]
        public string Picture { get; set; }
    }
}
