using Raylib_cs;
using Domain;

namespace SpaceApplication;

public class PlayerShipView: IGameObjectView
{
    public PlayerShipView(Ship ship, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.ship = ship;
    }

    private Texture2D texture;
    private Ship ship;

    public void Print()
    {
        Raylib.DrawTexture(texture, ship.RectPosition.X, ship.RectPosition.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }
}