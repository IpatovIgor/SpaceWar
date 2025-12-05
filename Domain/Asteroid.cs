namespace Domain;

public class Asteroid: GameObject, IGiveScore
{
    public Asteroid(IGameInput input, Position position, Size size, Health health,
        Speed speed, GameWorld world) 
        : base(input, position, size, health, speed, world)
    {
        Score = 5;
    }
    
    public void HitShips()
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
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        HitShips();
        bool wasDie = HP.Value <= 0;
        if (RectPosition.Y > 900 || HP.Value <= 0)
            Die();
        
        return wasDie;
    }

    public int Score { get; }
}