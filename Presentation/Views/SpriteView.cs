using Raylib_cs;
using Geometry;
namespace Presentation;

public class SpriteView: IGameObjectView
{
    public SpriteView(Point position, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        Position = position;
    }

    private Texture2D texture;

    public void Print()
    {
        Raylib.DrawTexture(texture, Position.X, Position.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }

    public Point Position { get; set; }
}