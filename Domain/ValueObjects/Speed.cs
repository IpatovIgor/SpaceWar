namespace Domain;

public class Speed(int speed): IEquatable<Speed>
{
    public readonly int Value = speed;

    public bool Equals(Speed? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Speed)obj);
    }

    public override int GetHashCode()
    {
        return Value;
    }
}