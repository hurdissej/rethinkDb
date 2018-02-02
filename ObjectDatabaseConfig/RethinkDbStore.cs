using RethinkDb.Driver;

namespace rethink.ObjectDatabaseConfig
{
    public class RethinkDbStore : IRethinkDbStore
    {
        private static IRethinkDbConnectionFactory _connectionFactory;
        private static RethinkDB R = RethinkDB.R;
        private string _dbName;

        public RethinkDbStore(IRethinkDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _dbName = connectionFactory.GetOptions().Database;
        }

        public void InitialiseDatabase()
        {
            CreateDb(_dbName);
        }

        private void CreateDb(string dbName)
        {
            var conn = _connectionFactory.CreateConnection();
            if (!R.DbList().Contains(db => dbName).Run(conn))
            {
                R.DbCreate(dbName).Run(conn);
                R.Db(dbName).Wait_().Run(conn);
                // Log that the databases have been created
            };
        }

        private void CreateTable(string dbName, string tableName)
        {
            var conn = _connectionFactory.CreateConnection();
            var exists = R.Db(dbName).TableList().Contains(t => t == tableName).Run(conn);
            if (!exists)
            {
                R.Db(dbName).TableCreate(tableName).Run(conn);
                R.Db(dbName).Table(tableName).Wait_().Run(conn);
            }
        }

        public void Reconfigure(int shards, int replicas) 
        { 
            var conn = _connectionFactory.CreateConnection(); 
            var tables = R.Db(_dbName).TableList().Run(conn); 
            foreach (string table in tables) 
            { R.Db(_dbName).Table(table).Reconfigure().OptArg("shards", shards).OptArg("replicas", replicas).Run(conn); 
                R.Db(_dbName).Table(table).Wait_().Run(conn);
            }
        }
    }
}