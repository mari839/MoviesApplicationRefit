using MoviesApplicationRefit.Models;
using Refit;

namespace MoviesApplicationRefit.Services
{
    [Headers("accept: application/json", //static request headers 
            "Authorization: Bearer")] //attribute on the interface (lowest priority)
    public interface ITmdbApi
    {
        [Get("/search/person?query={name}")] //updated dynamically using replacement blocks and parameters on the method, the complete path to query persons is https://api.themoviedb.org/3/search/person?query={name}
        Task<ApiResponse<ActorList>> GetActors(string name); // all requests must be async, either via Task or via IObservable

        [Get("/person/{actorId}/movie_credits?language=en-US")]
        Task<MovieList> GetMovies(int actorId);

        [Headers("Content-Type: application/json;charset=utf-8")] //attribute on method 
        [Post("/movie/{movieId}/rating")]
        Task<ResponseBody> AddRating(int movieId, [Body] Rating rating); //using body attribute is allows to use one of the attribute 

        [Delete("/movie/{movieId}/rating")]
        Task<ResponseBody> DeleteRating(int movieId);
    }
}
