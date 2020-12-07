using GoodWeebs.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodWeebs.Web.ViewModels.SubmissionInputModels
{
    public class MangaSubmissionInputModel
    {
        public string SubmissionType { get; set; }

        public string SubmitterId { get; set; }

        public string SubmissionUrl { get; set; }

        public ApplicationUser Submitter { get; set; }

        public string Title { get; set; }

        public string Genres { get; set; }

        public string Picture { get; set; }

        public string Type { get; set; }

        public string Synopsis { get; set; }


        public string Status { get; set; }

        public string Synonyms { get; set; }

        public string Volumes { get; set; }

        public string Chapters { get; set; }

        public string Published { get; set; }

        public string Rating { get; set; }

        public string Authors { get; set; }
    }
}
