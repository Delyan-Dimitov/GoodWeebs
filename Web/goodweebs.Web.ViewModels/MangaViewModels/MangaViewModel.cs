namespace GoodWeebs.Web.ViewModels.MangaViewModels
{
    public class MangaViewModel
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public string PictureUrl { get; set; }

        public string Synopsis { get; set; }

        public string Volumes { get; set; } = "Unknown";

        public string Type { get; set; } = "Unknown";

        public string Chapters { get; set; } = "Unknown";

        public string Published { get; set; } = "Unknown";

        public string Authors { get; set; } = "Unknown";

        public string Genres { get; set; } = "Unknown";

        public string Status { get; set; } = "Unkown";
    }
}
