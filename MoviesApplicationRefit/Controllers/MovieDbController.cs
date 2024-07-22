﻿using Microsoft.AspNetCore.Mvc;
using MoviesApplicationRefit.Models;
using MoviesApplicationRefit.Services;
using System.ComponentModel.DataAnnotations;

namespace MoviesApplicationRefit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDbController(ITmdbApi tmdbApi) : Controller
    {
        private readonly ITmdbApi _tmdbApi = tmdbApi;
        [HttpGet("actors/")]
        public async Task<ActorList> GetActors([FromQuery][Required] string name)
        {
            var result = new ActorList();
            var response = await _tmdbApi.GetActors(name);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content;
            }
            else
            {
                // log $"{response.Error}-{response.Error.Content}";
            }
            return result;
        }
        [HttpGet("actors/{actorId}/movies")]
        public async Task<MovieList> GetMovies(int actorId)
        {
            var response = await _tmdbApi.GetMovies(actorId);
            return response;
        }

        [HttpPost("movies/{movieId}/rating")]
        public async Task<ResponseBody> AddRating(int movieId, [FromBody] Rating rating)
        {
            var response = await _tmdbApi.AddRating(movieId, rating);
            return response;
        }

        [HttpDelete("movies/{movieId}/rating")]
        public async Task<ResponseBody> DeleteRating(int movieId)
        {
            var response = await _tmdbApi.DeleteRating(movieId);
            return response;
        }
    }
}
