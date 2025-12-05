namespace SpaceApplication;
using Domain;

public class Spawner
{
    private void Spawn()
    {
        for (var i = 0; i < 2; i++)
        {
            var x = random.Next(0, 1120);
            GameObject newObj = null;
            var flag = true;
            var nextObjInd = (TypeOfObjects) random.Next(0, 2);
            
            if (nextObjInd == TypeOfObjects.Asteroid)
                newObj = new Asteroid(new EnemyObjectInput(), new Position(x, 70),
                    new Size(85, 85), new Health(20), new Speed(9), gameWorld);
            if (nextObjInd == TypeOfObjects.Ship)
                newObj = new Ship(new EnemyShipInput(), new Position(x, 70),
                    new Size(85, 80), new Health(20), new Speed(9), gameWorld, Direction.Down);
            foreach (var obj in gameWorld.gameObjects)
            {
                if (obj.Equals(newObj))
                    continue;

                if (Collisions.TwoRectHaveCollisions(obj, newObj))
                {
                    flag = false;
                    break;
                }
            }
            
            if (!flag)
                newObj.Die();
        }
    }
    
    public Spawner(GameWorld world)
    {
        timer = new Timer(2);
        random = new Random();
        gameWorld = world;
    }

    private Timer timer;
    private GameWorld gameWorld;
    private Random random;
    
    public void TrySpawn()
    {
        var deltaTime = 0.01f;
        if (timer.Update(deltaTime))
        {
            Spawn();
        }
    }
}
