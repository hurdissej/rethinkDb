using System.Collections.Generic;
using rethink.ObjectDatabaseConfig;
using RethinkDb.Driver;
using RethinkDb.Driver.Net;

public class MovieRepository : IMovieRepository
{
    private readonly IRethinkDbConnectionFactory ConnectionFactory;
    private static RethinkDB R = RethinkDB.R;
    private string _dbName;
    public MovieRepository(IRethinkDbConnectionFactory connectionFactory)
    {
        this.ConnectionFactory = connectionFactory;

        _dbName = connectionFactory.GetOptions().Database;
    }

    public IEnumerable<Movie> GetAllMovies() 
    {
        var con = ConnectionFactory.CreateConnection();
        IEnumerable<Movie> movies = R.Db(_dbName).Table(nameof(Movie)).GetAll().Run(con);
        return movies;
    }
    public void InsertOrUpdate(Movie movie)
    {
        var con = ConnectionFactory.CreateConnection();
        R.Db(_dbName).Table(nameof(Movie)).Insert(movie).Run(con);
    }
}