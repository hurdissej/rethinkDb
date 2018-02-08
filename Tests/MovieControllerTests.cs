using System;
using rethink.Controllers.Movies;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class UnitTest1
    {
        private readonly MovieController target;
        private readonly Mock<IMovieRepository> IMovieRepository;
        private readonly Mock<IActorProvider> IActorRepository;

        public UnitTest1()
        {
            var movies = new List<Movie>(){new Movie(){Id = 1, Name = "Movie1", Actors = new List<Actor>()}};
            Mock<IMovieRepository> movieRepository = new Mock<IMovieRepository>();
            movieRepository.Setup(x => x.GetAllMovies()).Returns(movies);
            Mock<IActorProvider> actorRepository = new Mock<IActorProvider>();
            target = new MovieController(movieRepository.Object, actorRepository.Object);
        }
        
        [Fact]
        public void GetMovies_MoviesExistInDB_MoviesReturned()
        {
            var movies = target.GetMovies().ToList();

            Assert.Equal(1, movies.Count);
        }
    }
}
