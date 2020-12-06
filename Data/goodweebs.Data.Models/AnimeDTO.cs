namespace GoodWeebs.Data.Models
{
    using Newtonsoft.Json;

    public class AnimeDTO
    {
        // [JsonProperty("sources")]
        // public string[] Sources { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("episodes")]
        public string Episodes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("aired")]
        public string Aired { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("synonyms")]
        public string[] Synonyms { get; set; }

        [JsonProperty("genres")]
        public string[] Genres { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("duration")]
        public string EpisodeDuration { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("studios")]
        public string[] Studios { get; set; }
    }
}
