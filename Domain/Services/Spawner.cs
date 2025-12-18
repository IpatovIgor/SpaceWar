namespace Domain;
using Geometry;

public class Spawner: ISpawner
{
    private int range = 1;
    private int piggyBankForSpawn = 0;

    private void UpSpeedOfSpawn()
    {
        // Это мы короче увеличиваем количество объектов, который появятся за раз
        piggyBankForSpawn += 1;
        piggyBankForSpawn %= 5;
        range += piggyBankForSpawn / 4;
    }
    
    private void Spawn()
    {
        if (gameWorld == null)
            throw new InvalidGameStateException("GameWorld is not set");

        if (repository == null)
            throw new InvalidGameStateException("Repository is not set");
        
        for (var i = 0; i < range; i++)
        {
            var x = random.Next(GameConfig.Spawn.MinX, GameConfig.Spawn.MaxX);
            GameObject newObj = null;
            var nextObjInd = (TypeOfObjects) random.Next(0, 2);
        
            if (nextObjInd == TypeOfObjects.Asteroid)
                newObj = new Asteroid(
                    new EnemyObjectInput(), 
                    new Position(x, GameConfig.Spawn.StartY + 90),
                    GameConfig.Asteroid.Size,
                    new Health(GameConfig.Asteroid.Health),
                    new Speed(GameConfig.Asteroid.Speed),
                    repository);
        
            if (nextObjInd == TypeOfObjects.Ship)
                newObj = new Ship(
                    new EnemyShipInput(), 
                    new Position(x, GameConfig.Spawn.StartY),
                    GameConfig.EnemyShip.Size,
                    new Health(GameConfig.EnemyShip.Health),
                    new Speed(GameConfig.EnemyShip.Speed),
                    repository, 
                    Direction.Down);

            if (!gameWorld.CheckCollisionWithObject(newObj))
                newObj.RegisterInRepository();
        }

        UpSpeedOfSpawn();
    }

    private IGameObjectRepository repository;
    
    public Spawner(GameWorld world, IGameObjectRepository repository)
    {
        if (world == null) throw new ArgumentNullException(nameof(world));
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        
        this.repository = repository;
        timer = new Timer(2);
        random = new Random();
        gameWorld = world;
    }

    private Timer timer;
    private GameWorld gameWorld;
    private Random random;
    
    public void TrySpawn(float deltaTime)
    {
        if (timer.Update(deltaTime))
        {
            Spawn();
        }
    }
}
