using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IckleUrl.Models
{
    public class ShortUrl
    {
        [Required]
        [JsonProperty("fullurl")]
        public string FullUrl { get; set; }

        [JsonProperty("shortendurl")]
        public string ShortenedUrl { get; set; }

        [JsonProperty("error")]
        public string ErrorMessage { get; set; }
    }
}