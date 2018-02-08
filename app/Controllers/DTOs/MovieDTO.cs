using System.Collections.Generic;

public class MovieDTO
{
    public string Name { get; set; }
    public ICollection<int> ActorRef { get; set; }
}