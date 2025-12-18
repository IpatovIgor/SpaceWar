namespace Domain;
using Geometry;

public class GameException : Exception
{
    public GameException(string message) : base(message) { }
    public GameException(string message, Exception inner) : base(message, inner) { }
}

public class InvalidGameStateException : GameException
{
    public InvalidGameStateException(string message) : base(message) { }
}

public class InvalidPositionException : GameException
{
    public InvalidPositionException(Position position) 
        : base($"Invalid position: ({position.X}, {position.Y})") { }
}

public class CollisionException : GameException
{
    public CollisionException(GameObject obj1, GameObject obj2) 
        : base($"Collision between {obj1.GetType().Name} and {obj2.GetType().Name}") { }
}

public class HealthBelowZeroException : GameException
{
    public HealthBelowZeroException(int health) 
        : base($"Health cannot be below zero: {health}") { }
}