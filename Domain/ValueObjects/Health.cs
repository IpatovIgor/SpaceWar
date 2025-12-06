namespace Domain;

public class Health(int health): IEquatable<Health>
{
    public int Value { get; } = health;

    public bool Equals(Health? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public Health GetDamage(int damage)
    {
        return new Health(Value - damage);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Health)obj);
    }

    public override int GetHashCode()
    {
        return Value;
    }
}