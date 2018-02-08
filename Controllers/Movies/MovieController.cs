using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace rethink.Controllers.Movies
{
    [Route("api/Movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorProvider actorRepository;

        public MovieController(IMovieRepository movieRepository, IActorProvider actorRepository)
        {
            this.movieRepository = movieRepository;
            this.actorRepository = actorRepository;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Movie> GetMovies()
        {
            return movieRepository.GetAllMovies();
        }

        [HttpPost]
        [Route("newMovie")]
        public void CreateMovie([FromBody]MovieDTO movieDTO)
        {
            var actors = GetActorList(movieDTO.ActorRef);
            var movie = new Movie(){
                Name = movieDTO.Name,
                Actors = actors
            };
            movieRepository.InsertOrUpdate(movie);
        }

        private List<Actor> GetActorList(ICollection<int> actorRefs)
        {
            var actors = new List<Actor>();
            foreach(var actor in actorRefs)
            {
                var exists = actorRepository.DoesActorExist(actor, out Actor actorToBeAdded);
                if(exists)
                    actors.Add(actorToBeAdded);
            }
            return actors;
        }
    }

}