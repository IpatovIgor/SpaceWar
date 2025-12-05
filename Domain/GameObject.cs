namespace Domain;

public abstract class GameObject: IRectangle
{
    protected GameWorld gameWorld;

    public void GetDamage(int damage)
    {
        HP.Value -= damage;
    }
    
    protected void MoveLeft()
    {
        if (RectPosition.X - speed.Value < 0)
            return;
        RectPosition.X -= speed.Value;
    }
    
    protected void MoveRight()
    {
        if (RectPosition.X + speed.Value > 1150)
            return;
        RectPosition.X += speed.Value;
    }
    
    protected void MoveUp()
    {
        if (RectPosition.Y - speed.Value < 0)
            return;
        RectPosition.Y -= speed.Value;
    }
    
    protected void MoveDown()
    {
        if (RectPosition.Y + speed.Value > 900)
            return;
        RectPosition.Y += speed.Value;
    }

    private Speed speed;
    
    protected GameObject(IGameInput input, Position position, Size size, Health health, Speed speed, GameWorld world)
    {
        this.speed = speed;
        gameWorld = world;
        this.input = input;
        RectPosition = position;
        HP = health;
        RectSize = size;
        gameWorld.Add(this);
    }

    public bool IsDead { get; private set; } = false;

    public void Die()
    {
        gameWorld.Remove(this);
        IsDead = true;
    }
    
    public int Width { get; protected set; }
    
    public int Height { get; protected set; }

    protected IGameInput input;

    public Health HP { get; protected set; }
    
    public abstract bool Update();
    
    public Position RectPosition { get; private set; }
    
    public Size RectSize { get; private set; }
}