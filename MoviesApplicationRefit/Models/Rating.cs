using System.Text.Json.Serialization;

namespace MoviesApplicationRefit.Models
{
    public class Rating
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
    }
}
