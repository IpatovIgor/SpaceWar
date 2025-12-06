namespace Domain;

public class Size(int w, int h): IEquatable<Size>
{
    public readonly int Width = w;
    
    public readonly int Height = h;

    public bool Equals(Size? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Width == other.Width && Height == other.Height;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Size)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }
}