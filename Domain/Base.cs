namespace Domain;

public class Base: Ship
{
    public Base(IGameInput input, Position position, Size size, Health health, 
        Speed speed, GameWorld world, Direction dir) 
        : base(input, position, size, health, speed, world, dir) { }
}