namespace Domain;

public class Bullet: GameObject, IDamageable
{
    public Bullet(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository ,Direction dir)
        : base(input, position, size, health, speed, repository)
    {
        Damage = 10;
    }
    
    public override void Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveUp)
                MoveUp();
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        if (RectPosition.Y < 20 || HP.Value <= 0 || RectPosition.Y > 900)
            Die();
    }

    public int Damage { get; }
    public void TakeDamage(GameObject obj)
    {
        obj.GetDamage(Damage);
        GetDamage(100);
    }
}