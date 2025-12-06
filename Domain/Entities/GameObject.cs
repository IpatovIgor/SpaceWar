namespace Domain;

public abstract class GameObject: IRectangle
{
    public void GetDamage(int damage)
    {
        HP = HP.GetDamage(damage);
    }
    
    protected void MoveLeft()
    {
        if (RectPosition.X - speed.Value < 0)
            return;
        RectPosition = RectPosition.Move(-speed.Value, 0);
    }
    
    protected void MoveRight()
    {
        if (RectPosition.X + speed.Value > 1150)
            return;
        RectPosition = RectPosition.Move(speed.Value, 0);
    }
    
    protected void MoveUp()
    {
        if (RectPosition.Y - speed.Value < 0)
            return;
        RectPosition = RectPosition.Move(0, -speed.Value);
    }
    
    protected void MoveDown()
    {
        if (RectPosition.Y + speed.Value > 900)
            return;
        RectPosition = RectPosition.Move(0, speed.Value);
    }

    private Speed speed;
    
    protected GameObject(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository)
    {
        this.repository = repository;
        this.speed = speed;
        this.input = input;
        RectPosition = position;
        HP = health;
        RectSize = size;
        
        this.repository.Add(this);
    }

    protected IGameObjectRepository repository;

    public bool IsDead { get; private set; } = false;

    public void Die()
    {
        repository.Remove(this);
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