namespace Domain;

public class Asteroid: GameObject, IGiveScore, IDamageable
{
    public Asteroid(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository) 
        : base(input, position, size, health, speed, repository)
    {
        Score = 5;
        Damage = 10;
    }
    
    public override bool Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        bool wasDie = HP.Value <= 0;
        if (RectPosition.Y > 900 || HP.Value <= 0)
            Die();
        
        return wasDie;
    }

    public int Score { get; }
    public int Damage { get; }
    public void TakeDamage(GameObject obj)
    {
        obj.GetDamage(Damage);
        GetDamage(100);
    }
}