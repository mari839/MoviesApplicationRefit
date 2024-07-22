using System.Text.Json.Serialization;

namespace MoviesApplicationRefit.Models
{
    public class MovieList
    {
        [JsonPropertyName("cast")]
        public List<Movie> Movies { get; set; }
    }
}
