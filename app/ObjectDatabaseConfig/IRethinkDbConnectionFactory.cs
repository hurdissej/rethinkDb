using RethinkDb.Driver.Net;

namespace rethink.ObjectDatabaseConfig
{
    public interface IRethinkDbConnectionFactory
    {
        Connection CreateConnection();
        void CloseConnection();
        RethinkDbOptions GetOptions(); 
    }
}