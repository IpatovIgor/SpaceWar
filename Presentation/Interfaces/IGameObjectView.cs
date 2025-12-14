using Point = Geometry.Point;

namespace Presentation;

public interface IGameObjectView
{
    public void Print();
    public void UnloadTexture();

    public void UpdatePosition(Point point)
    {
        Position = point;
    }
    
    public Point Position { get; protected set; }
    
    
}