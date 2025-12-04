namespace SpaceApplication;
using Raylib_cs;
using Domain;

public class Spawner:ISpawner
{
    private void Spawn(IStatController statController)
    {
        for (var i = 0; i < 2; i++)
        {
            var x = random.Next(0, 1120);
            GameObject newObj = null;
            var flag = true;
            var nextObjInd = (TypeOfObjects) random.Next(0, 2);
            
            if (nextObjInd == TypeOfObjects.Asteroid)
                newObj = new Asteroid(new EnemyObjectInput(), StaticData.GenerateAsteroid(x, 70), gameObjects);
            if (nextObjInd == TypeOfObjects.Ship)
                newObj = new Ship(new EnemyShipInput(), StaticData.GenerateEnemyShip(x, 0),
                    gameObjects, GameEvents.MoveDown);
            foreach (var obj in gameObjects)
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
    
    public Spawner(List<GameObject> list)
    {
        timer = new Timer(2);
        random = new Random();
        gameObjects = list;
    }

    private Timer timer;
    private List<GameObject> gameObjects;
    private Random random;
    
    public void TrySpawn(IStatController statController)
    {
        var deltaTime = Raylib.GetFrameTime();
        if (timer.Update(deltaTime))
        {
            Spawn(statController);
        }
    }
}
