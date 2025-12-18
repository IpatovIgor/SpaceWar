namespace Domain;
using Geometry;

public abstract class GameObject: IRectangle
{
    public void GetDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException("Damage cannot be negative", nameof(damage));
        
        HP = new Health(HP.Value - damage);
    }
    
    protected void MoveLeft()
    {
        if (RectPosition.X - speed.Value < 0)
            return;
        RectPosition = RectPosition.Move(-speed.Value, 0);
    }

    protected void MoveRight()
    {
        if (RectPosition.X + speed.Value + RectSize.Width > GameConfig.ScreenWidth)
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
        if (RectPosition.Y + speed.Value + RectSize.Height > GameConfig.ScreenHeight)
            return;
        RectPosition = RectPosition.Move(0, speed.Value);
    }
    
    private Speed speed;
    
    protected GameObject(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (position == null) throw new ArgumentNullException(nameof(position));
        if (size == null) throw new ArgumentNullException(nameof(size));
        if (health == null) throw new ArgumentNullException(nameof(health));
        if (speed == null) throw new ArgumentNullException(nameof(speed));
        if (repository == null) throw new ArgumentNullException(nameof(repository));
        
        if (health.Value < 0)
            throw new HealthBelowZeroException(health.Value);
    
        if (speed.Value < 0)
            throw new ArgumentException("Speed cannot be negative", nameof(speed));
    
        if (!GameConfig.IsInBounds(position, size, this is Base))
            throw new InvalidPositionException(position);
        
        
        this.speed = speed;
        this.input = input;
        RectPosition = position;
        HP = health;
        RectSize = size;
        this.repository = repository;
    }

    private IGameObjectRepository repository;

    public void RegisterInRepository()
    {
        if (repository == null)
            throw new InvalidGameStateException("Repository is not set");
    
        if (IsDead)
            throw new InvalidGameStateException("Cannot register dead object");
        
        repository.Add(this);
    }
    
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
    
    public abstract void Update();
    
    public Position RectPosition { get; private set; }
    
    public Size RectSize { get; private set; }
}