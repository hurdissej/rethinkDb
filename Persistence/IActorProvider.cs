public interface IActorProvider
{
    bool DoesActorExist(int actorRef, out Actor actor);
    void AddActorToDB(Actor actor);
}