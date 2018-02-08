using System.Collections.Generic;

public interface IMovieRepository
{
    IEnumerable<Movie> GetAllMovies(); 
    void InsertOrUpdate(Movie movie);
}