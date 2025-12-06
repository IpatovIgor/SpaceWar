namespace Domain;

public class Position(int x, int y): IEquatable<Position>
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public Position Move(int deltaX, int deltaY)
    {
        return new Position(X + deltaX, Y + deltaY);
    }

    public bool Equals(Position? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Position)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}