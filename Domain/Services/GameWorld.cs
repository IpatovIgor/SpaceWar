namespace Domain;

public class GameWorld
{
    
    private IStatController statController = new StatController();
    
    public List<GameObject> gameObjects = new List<GameObject>();

    public void Add(GameObject obj)
    {
        gameObjects.Add(obj);
    }

    public void Remove(GameObject obj)
    {
        gameObjects.Remove(obj);
    }

    public bool CheckCollisionWhithObject(GameObject newObj)
    {
        var flag = false;
        
        foreach (var obj in gameObjects)
        {
            if (obj.Equals(newObj))
                continue;

            if (Collisions.TwoRectHaveCollisions(obj, newObj))
            {
                flag = true;
                break;
            }
        }

        return flag;
    }
    
    public List<T> GetObjectsOfType<T>() where T : GameObject
    {
        return gameObjects.OfType<T>().ToList();
    }

    public void CheckCollisions()
    {
        foreach (var firstObj in gameObjects)
        {
            foreach (var secondObj in gameObjects.Where(secondObj =>
                         !firstObj.Equals(secondObj)).Where(secondObj =>
                         Collisions.TwoRectHaveCollisions(firstObj, secondObj)))
            {
                if (firstObj is IDamageable damageable)
                    damageable?.TakeDamage(secondObj);
                    
                if (secondObj is IDamageable obj)
                    obj?.TakeDamage(firstObj);
            }
        }
    }
    
    public void UpdateAllObjects()
    {
        CheckCollisions();
        
        for (var i = gameObjects.Count - 1; i >= 0; i--)
        {
            var die = gameObjects[i].Update();
            if (die)
                statController.AddScore(10);
        }
    }
}