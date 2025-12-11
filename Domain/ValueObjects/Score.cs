namespace Domain;

public class Score(int score): IEquatable<Score>
{
    public readonly int Value = score;

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
        return Equals((Score)obj);
    }

    public override int GetHashCode()
    {
        return Value;
    }

    public bool Equals(Score? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }
}    