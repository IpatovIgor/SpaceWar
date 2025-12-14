using Domain;
using Presentation;
using Geometry;
namespace SpaceApplication;

public class ViewManager(GameWorld world)
{
    private GameWorld gameWorld = world;
    private ViewFactory factory = new ViewFactory();
    private Dictionary<GameObject ,IGameObjectView> connectionDict = new Dictionary<GameObject, IGameObjectView>();
    public List<IGameObjectView> ViewsObjects { get; private set; } = new List<IGameObjectView>();

    private void DeleteDeadView()
    {
        var viewersForDelete = new List<IGameObjectView>();
        
        foreach (var view in ViewsObjects)
        {
            var obj = connectionDict.FirstOrDefault(x => x.Value == view).Key;
            if (obj.IsDead)
            {
                viewersForDelete.Add(view);
                connectionDict.Remove(obj);
            }
        }

        foreach (var obj in viewersForDelete)
        {
            obj.UnloadTexture();
            ViewsObjects.Remove(obj);
        }
    }
    
    public void UpdateViewers()
    {
        DeleteDeadView();
        
        foreach (var obj in gameWorld.gameObjects)
        {
            if (connectionDict.ContainsKey(obj))
            {
                connectionDict[obj].UpdatePosition(new Point(obj.RectPosition.X, obj.RectPosition.Y));
                continue;
            }

            var viewObj = factory.CreateView(obj);
            ViewsObjects.Add(viewObj);
            connectionDict[obj] = viewObj;
        }
    }
}