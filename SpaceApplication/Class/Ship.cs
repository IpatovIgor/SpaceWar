using System.Xml;
using Domain;
using Raylib_cs;

namespace SpaceApplication;

public class ShipView: IGameObjectView
{
    public ShipView(Ship ship, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.ship = ship;
    }
    
    private readonly Texture2D texture;
    private readonly Ship ship;

    public void Print()
    {
        Raylib.DrawTexture(texture, ship.RectPosition.X, ship.RectPosition.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }
}