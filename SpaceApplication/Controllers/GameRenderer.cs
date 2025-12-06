using Presentation;
namespace SpaceApplication;

public class GameRenderer
{
    public void Render(IEnumerable<IGameObjectView> objects)
    {
        foreach (var viewer in objects)
        {
            viewer.Print();
        }
    }
}