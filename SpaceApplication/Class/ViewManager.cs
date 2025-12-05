using Domain;
namespace SpaceApplication.Class;

public class ViewManager(GameWorld world)
{
    private GameWorld gameWorld = world;
    private ViewFactory factory = new ViewFactory();
    private Dictionary<GameObject ,IGameObjectView> connectionDict = new Dictionary<GameObject, IGameObjectView>();
    public List<IGameObjectView> ViewsObjects { get; private set; } = new List<IGameObjectView>();

    public void UpdateViewers()
    {
        foreach (var obj in gameWorld.gameObjects)
        {
            if (connectionDict.ContainsKey(obj))
            {
                if (obj.IsDead)
                {
                    connectionDict[obj].UnloadTexture();
                    ViewsObjects.Remove(connectionDict[obj]);
                    connectionDict.Remove(obj);
                }

                continue;
            }
            
            var viewObj = factory.CreateView(obj);
            ViewsObjects.Add(viewObj);
            connectionDict[obj] = viewObj;
        }
    }

    public void PrintAll()
    {
        foreach (var viewer in ViewsObjects)
        {
            viewer.Print();
        }
    }
}