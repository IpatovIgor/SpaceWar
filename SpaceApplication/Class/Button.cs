using Raylib_cs;

namespace SpaceApplication;

public class Button: IButton
{
    public Button(string pathToTexture, int x, int y, int w, int h)
    {
        texture = Raylib.LoadTexture(pathToTexture);
        X = x;
        Y = y;
        Width = w;
        Height = h;
    }
    
    public Action OnClick { get; set; }

    private Texture2D texture;

    public void Print()
    {
        Raylib.DrawTexture(texture, X, Y, Color.White);
    }

    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
}