using rethink.ObjectDatabaseConfig;
using RethinkDb.Driver;
using RethinkDb.Driver.Linq;
using System.Linq;
using System;

public class ActorProvider: IActorProvider 
{
    private readonly IRethinkDbConnectionFactory connectionFactory;
    private static RethinkDB R = RethinkDB.R;
    private string _dbName;

    public ActorProvider(IRethinkDbConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
        this._dbName = connectionFactory.GetOptions().Database;
    }

    public bool DoesActorExist(int actorRef, out Actor actor)
    {
        var con = connectionFactory.CreateConnection();
        var actorInDb = R.Db(_dbName).Table(nameof(Actor)).GetAll().Run(con);
        actor = new Actor()
        {
            Id = actorRef,
            Name = "SomeName",
            DoB = new DateTime(),

        };
        return true;
    }


    void IActorProvider.AddActorToDB(Actor actor)
    {
        throw new System.NotImplementedException();
    }
}