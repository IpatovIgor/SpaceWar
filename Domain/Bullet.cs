namespace Domain;

public class Bullet: GameObject
{
    public Bullet(IGameInput input, Position position, Size size, Health health,
        Speed speed, GameWorld world, Direction dir) 
        : base(input, position, size, health, speed, world) { }

    private void HitShips()
    {
        foreach (var obj in gameWorld.GetObjectsOfType<GameObject>())
        {
            if (obj.Equals(this))
                continue;

            if (Collisions.TwoRectHaveCollisions(this, obj))
            {
                obj.GetDamage(10);
                GetDamage(10);
            }
        }
    }

    public override bool Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveUp)
                MoveUp();
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        HitShips();
        if (RectPosition.Y < 20 || HP.Value <= 0 || RectPosition.Y > 900)
            Die();
        return false;
    }
}