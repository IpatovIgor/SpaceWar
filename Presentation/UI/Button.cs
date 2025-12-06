using System.Numerics;
using Raylib_cs;

namespace Presentation;

public class Button
{
    private readonly Texture2D texture;
    private readonly Rectangle bounds;
    
    public Button(string texturePath, int x, int y)
    {
        texture = Raylib.LoadTexture(texturePath);
        bounds = new Rectangle(x, y, texture.Width, texture.Height);
    }
    
    public Button(string texturePath, int x, int y, int width, int height)
    {
        texture = Raylib.LoadTexture(texturePath);
        bounds = new Rectangle(x, y, width, height);
    }
    
    public Action OnClick { get; set; }
    
    public Rectangle Bounds => bounds;
    
    public bool ContainsPoint(Vector2 point)
    {
        return Raylib.CheckCollisionPointRec(point, bounds);
    }
    
    public void Draw()
    {
        Raylib.DrawTexture(texture, 
            (int)bounds.X, 
            (int)bounds.Y, 
            Color.White);
    }
    
    public void Unload()
    {
        Raylib.UnloadTexture(texture);
    }
}