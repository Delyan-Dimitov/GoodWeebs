using Newtonsoft.Json;

namespace GoodWeebs.Data.Models
{
    public class MangaDto
    {
        public string Title { get; set; }

        public string Synopsis { get; set; }

        [JsonProperty("picture")]
        public string PictureUrl { get; set; }

        [JsonProperty("type")] // TODO check if this works
        public string Type { get; set; }

        public string Volumes { get; set; }

        public string Chapters { get; set; }

        [JsonProperty("published")]
        public string Published { get; set; }

        public string[] Authors { get; set; }

        public string Status { get; set; }

        public string[] Genres { get; set; }

    }
}
