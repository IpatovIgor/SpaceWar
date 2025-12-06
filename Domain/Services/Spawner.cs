namespace Domain;

public class Spawner
{
    private void Spawn()
    {
        for (var i = 0; i < 2; i++)
        {
            var x = random.Next(0, 1120);
            GameObject newObj = null;
            var nextObjInd = (TypeOfObjects) random.Next(0, 2);
            
            if (nextObjInd == TypeOfObjects.Asteroid)
                newObj = new Asteroid(new EnemyObjectInput(), new Position(x, 70),
                    new Size(85, 85), new Health(20), new Speed(3), repository);
            if (nextObjInd == TypeOfObjects.Ship)
                newObj = new Ship(new EnemyShipInput(), new Position(x, 70),
                    new Size(85, 80), new Health(20), new Speed(3), repository, Direction.Down);

            var flag = gameWorld.CheckCollisionWithObject(newObj);
            
            if (!flag)
                repository.Add(newObj);
        }
    }

    private IGameObjectRepository repository;
    
    public Spawner(GameWorld world, IGameObjectRepository repository)
    {
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
