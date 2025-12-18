using Raylib_cs;
namespace Presentation;

public class Background : IDisposable
{
    private readonly Texture2D texture;
    private readonly int offsetX;
    private readonly int offsetY;
    
    public Background(string texturePath, int offsetX = 0, int offsetY = 0)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }
    
    public void Draw()
    {
        Raylib.DrawTexture(texture, offsetX, offsetY, Color.White);
    }
    
    public void Dispose()
    {
        Raylib.UnloadTexture(texture);
    }
}