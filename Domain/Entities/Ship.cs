namespace Domain;
using Geometry;

public class Ship : GameObject, IGiveScore
{
    public Ship(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository, Direction dir) 
        : base(input, position, size, health, speed, repository)
    {
        Score = GameConfig.EnemyShip.Score;
        direction = dir;
        this.repository = repository;
    }

    private IGameObjectRepository repository;
    private Direction direction;

    protected void Shoot()
    {
        GameObject obj = null;
        if (direction == Direction.Up)
            obj = new Bullet(
                new BulletInput(direction), 
                new Position(
                    RectPosition.X + GameConfig.Player.BulletOffsetX, 
                    RectPosition.Y + GameConfig.Player.BulletOffsetUpY),
                GameConfig.Bullet.Size,
                new Health(GameConfig.Bullet.Health),
                new Speed(GameConfig.Bullet.Speed),
                repository, 
                direction);
        else
            obj = new Bullet(
                new BulletInput(direction), 
                new Position(
                    RectPosition.X + GameConfig.Player.BulletOffsetX, 
                    RectPosition.Y + GameConfig.Player.BulletOffsetDownY),
                GameConfig.Bullet.Size,
                new Health(GameConfig.Bullet.Health),
                new Speed(GameConfig.Bullet.Speed),
                repository, 
                direction);
    
        obj.RegisterInRepository();
    }
    
    public override void Update()
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

        if (RectPosition.Y > 800 || HP.Value <= 0)
            Die();
    }
    
    public int Score { get; }
}