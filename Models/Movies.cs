using System.Collections.Generic;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Actor> Actors { get; set; }
}