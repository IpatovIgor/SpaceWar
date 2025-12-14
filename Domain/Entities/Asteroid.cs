namespace Domain;
using Geometry;

public class Asteroid: GameObject, IGiveScore, IDamageable
{
    public Asteroid(IGameInput input, Position position, Size size, Health health,
        Speed speed, IGameObjectRepository repository) 
        : base(input, position, size, health, speed, repository)
    {
        Score = GameConfig.Asteroid.Score;
        Damage = GameConfig.Asteroid.Damage;
    }
    
    public override void Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        bool wasDie = HP.Value <= 0;
        if (RectPosition.Y > GameConfig.ScreenHeight - 100 || HP.Value <= 0)
            Die();
    }

    public int Score { get; }
    public int Damage { get; }
    public void TakeDamage(GameObject obj)
    {
        obj.GetDamage(Damage);
        GetDamage(Damage);
    }
}