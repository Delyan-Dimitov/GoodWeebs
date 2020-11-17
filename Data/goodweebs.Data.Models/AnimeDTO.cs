using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace goodweebs.Data.Models
{
    public class AnimeDTO
    {
        [JsonProperty("sources")]
        public string[] Sources { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("episodes")]
        public int Episodes { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("animeSeason")]
        public AnimeSeason AnimeSeason { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("synonyms")]
        public string[] Synonyms { get; set; }

        [JsonProperty("Relations")]
        public string[] Relations { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }


    }

    public class AnimeSeason
    {
        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("year")]
        public int? Year { get; set; }
    }
}
