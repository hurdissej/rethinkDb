using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace rethink.Controllers.Movies
{
    [Route("api/Movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;

        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Movie> GetMovies()
        {
            return movieRepository.GetAllMovies();
        }
    }

}