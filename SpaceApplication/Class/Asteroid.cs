using Domain;
using Raylib_cs;
namespace SpaceApplication;

public class AsteroidView: IGameObjectView
{
    public AsteroidView(Asteroid asteroid, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.asteroid = asteroid;
    }

    private Texture2D texture;
    private Asteroid asteroid;

    public void Print()
    {
        Raylib.DrawTexture(texture, asteroid.RectPosition.X, asteroid.RectPosition.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }
}