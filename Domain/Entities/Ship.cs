namespace Domain;

public class Ship : GameObject, IGiveScore
{
    public Ship(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository, Direction dir) 
        : base(input, position, size, health, speed, repository)
    {
        Score = 10;
        direction = dir;
    }
    
    private Direction direction;

    private void Shoot()
    {
        GameObject obj = null;
        if (direction == Direction.Up)
            obj = new Bullet(new BulletInput(direction), new Position(RectPosition.X + 29, RectPosition.Y - 26),
                new Size(25, 25), new Health(20), new Speed(9), repository, direction);
        else
            obj = new Bullet(new BulletInput(direction), new Position(RectPosition.X + 29, RectPosition.Y + 90),
                new Size(25, 25), new Health(20), new Speed(9), repository, direction);
        repository.Add(obj);
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