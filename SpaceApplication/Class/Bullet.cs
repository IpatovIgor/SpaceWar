using System.Xml;
using Domain;
using Raylib_cs;

namespace SpaceApplication;

public class BulletView:IGameObjectView
{
    public BulletView(Bullet bullet, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.bullet = bullet;
    }

    private Texture2D texture;
    private Bullet bullet;

    public void Print()
    {
        Raylib.DrawTexture(texture, bullet.RectPosition.X, bullet.RectPosition.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }
}