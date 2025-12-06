using Domain;
namespace SpaceApplication.Class;

public class ViewManager(GameWorld world)
{
    private GameWorld gameWorld = world;
    private ViewFactory factory = new ViewFactory();
    private Dictionary<GameObject ,IGameObjectView> connectionDict = new Dictionary<GameObject, IGameObjectView>();
    public List<IGameObjectView> ViewsObjects { get; private set; } = new List<IGameObjectView>();

    private void DelateDeadView()
    {
        var viewersForDelate = new List<IGameObjectView>();
        
        foreach (var view in ViewsObjects)
        {
            var obj = connectionDict.FirstOrDefault(x => x.Value == view).Key;
            if (obj.IsDead)
            {
                viewersForDelate.Add(view);
                connectionDict.Remove(obj);
            }
        }

        foreach (var obj in viewersForDelate)
        {
            obj.UnloadTexture();
            ViewsObjects.Remove(obj);
        }
    }
    
    public void UpdateViewers()
    {
        DelateDeadView();
        
        foreach (var obj in gameWorld.gameObjects)
        {
            if (connectionDict.ContainsKey(obj))
                continue;
            
            var viewObj = factory.CreateView(obj);
            ViewsObjects.Add(viewObj);
            connectionDict[obj] = viewObj;
        }
        
        PrintAll();
    }

    private void PrintAll()
    {
        foreach (var viewer in ViewsObjects)
        {
            viewer.Print();
        }
    }
}