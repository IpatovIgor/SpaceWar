namespace Domain;

public interface IDamageable
{
    public int Damage { get; }

    public void TakeDamage(GameObject obj);
}