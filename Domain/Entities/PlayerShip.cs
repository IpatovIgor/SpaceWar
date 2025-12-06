namespace Domain;

public class PlayerShip: Ship
{
    public PlayerShip(IGameInput input, Position position, Size size, Health health, 
        Speed speed, IGameObjectRepository repository, Direction dir) 
        : base(input, position, size, health, speed, repository, dir) { }
}