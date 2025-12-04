using Domain;
using Raylib_cs;

namespace SpaceApplication;

public abstract class GameObject: IRectangle
{
    protected List<GameObject> objList;

    protected Texture2D texture;

    public void GetDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine(1);
    }
    protected void MoveLeft()
    {
        if (X - speed < 0)
            return;
        X -= speed;
    }
    
    protected void MoveRight()
    {
        if (X + speed > 1150)
            return;
        X += speed;
    }
    
    protected void MoveUp()
    {
        if (Y - speed < 0)
            return;
        Y -= speed;
    }
    
    protected void MoveDown()
    {
        if (Y + speed > 900)
            return;
        Y += speed;
    }

    private int speed;
    
    protected GameObject(IGameInput input, DataForObjects data, List<GameObject> list)
    {
        speed = data.Speed;
        texture = Raylib.LoadTexture(data.ImagePath);
        objList = list;
        this.input = input;
        X = data.X;
        Y = data.Y;
        HP = data.HP;
        Width = data.W;
        Height = data.H;
        objList.Add(this);
    }

    public void Die()
    {
        Raylib.UnloadTexture(texture);
        objList.Remove(this);
    }
    
    protected void Print()
    {
        Raylib.DrawTexture(texture, X, Y, Color.White);
    }
    
    public int Width { get; protected set; }
    
    public int Height { get; protected set; }

    protected IGameInput input;

    public int HP { get; protected set; }
    
    public abstract bool Update();
    public int X { get; private set; }
    public int Y { get; protected set; }
}