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
    
    public List<T> GetObjectsOfType<T>() where T : GameObject
    {
        return gameObjects.OfType<T>().ToList();
    }
    
    public void UpdateAllObjects()
    {
        for (var i = gameObjects.Count - 1; i >= 0; i--)
        {
            var die = gameObjects[i].Update();
            if (die)
                statController.AddScore(10);
        }
    }
}