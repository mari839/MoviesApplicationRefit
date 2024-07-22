﻿using System.Text.Json.Serialization;

namespace MoviesApplicationRefit.Models
{
    public class ActorList
    {
        [JsonPropertyName("results")]
        public List<Actor> Actors { get; set; }
    }
}
