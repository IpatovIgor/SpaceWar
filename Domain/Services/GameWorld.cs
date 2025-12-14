namespace Domain;
using Geometry;

public class GameWorld
{
    
    public IStatController statController {get; set;} = new StatController();
    
    public List<GameObject> gameObjects {get; set;} = new List<GameObject>();

    public void Add(GameObject obj)
    {
        gameObjects.Add(obj);
    }

    public void Remove(GameObject obj)
    {
        gameObjects.Remove(obj);
    }

    public virtual bool CheckCollisionWithObject(IRectangle newObj)
    {
        var flag = false;
        
        foreach (var obj in gameObjects)
        {
            if (obj.Equals(newObj))
                continue;

            if (!Collisions.TwoRectHaveCollisions(obj, newObj)) continue;
            flag = true;
            break;
        }

        return flag;
    }
    
    public List<T> GetObjectsOfType<T>() where T : GameObject
    {
        return gameObjects.OfType<T>().ToList();
    }

    private void CheckCollisions()
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
            var obj = gameObjects[i];
            obj.Update();
            UpdateStatForObj(obj);
        }
    }

    public void UpdateStatForObj(GameObject gameObject)
    {
        if (gameObject.IsDead && gameObject is IGiveScore score)
            statController.AddScore(score.Score);

        if (gameObject is PlayerShip playerShip)
            statController.UpdatePlayerHP(playerShip.HP.Value);
        
        if (gameObject is Base @base)
            statController.UpdateBaseHP(@base.HP.Value);
    }
}