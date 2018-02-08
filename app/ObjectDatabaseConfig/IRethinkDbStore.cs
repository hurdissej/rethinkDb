namespace rethink.ObjectDatabaseConfig
{
    public interface IRethinkDbStore
    {
        void InitialiseDatabase();
        void Reconfigure(int shards, int replicas); 
    }
}