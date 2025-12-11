namespace Domain;

public class GameObjectRepository(GameWorld world): IGameObjectRepository
{
    private GameWorld gameWorld = world;
    
    public void Add(GameObject obj)
    {
        gameWorld.Add(obj);    
    }

    public void Remove(GameObject obj)
    {
        gameWorld.Remove(obj);
    }
}