namespace Domain;

public class Ship : GameObject, IGiveScore
{
    public Ship(IGameInput input, Position position, Size size, Health health,
        Speed speed, GameWorld world, Direction dir) 
        : base(input, position, size, health, speed, world)
    {
        Score = 10;
        direction = dir;
    }
    
    private Direction direction;

    private void Shoot()
    {
        if (direction == Direction.Up)
            new Bullet(new BulletInput(direction), new Position(RectPosition.X + 29, RectPosition.Y - 26),
                new Size(25, 25), new Health(20), new Speed(9), gameWorld, direction);
        else
            new Bullet(new BulletInput(direction), new Position(RectPosition.X + 29, RectPosition.Y + 90),
                new Size(25, 25), new Health(20), new Speed(9), gameWorld, direction);
    }
    
    public override bool Update()
    {
        var eventsList = input.GetEvents();
        foreach (var gameEvent in eventsList)
        {
            switch (gameEvent)
            {
                case GameEvents.MoveLeft:
                    MoveLeft();
                    break;
                case GameEvents.MoveRight:
                    MoveRight();
                    break;
                case GameEvents.MoveUp:
                    MoveUp();
                    break;
                case GameEvents.MoveDown:
                    MoveDown();
                    break;
                case GameEvents.Shoot:
                    Shoot();
                    break;
            }
        }

        var wasDie = false;

        if (HP.Value <= 0 || RectPosition.Y > 800)
        {
            Die();
            wasDie = true;
        }
        
        return wasDie;
    }
    
    public int Score { get; }
}