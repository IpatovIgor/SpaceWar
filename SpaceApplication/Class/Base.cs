using Raylib_cs;
using SpaceApplication;

namespace Domain;

public class BaseView: IGameObjectView
{
    public BaseView(Base myBase, string texturePath)
    {
        texture = Raylib.LoadTexture(texturePath);
        this.myBase = myBase;
    }

    private Texture2D texture;
    private Base myBase;

    public void Print()
    {
        Raylib.DrawTexture(texture, myBase.RectPosition.X, myBase.RectPosition.Y, Color.White);
    }

    public void UnloadTexture()
    {
        Raylib.UnloadTexture(texture);
    }
}