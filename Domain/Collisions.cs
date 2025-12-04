namespace Domain;

public static class Collisions
{
    public static bool TwoRectHaveCollisions(IRectangle a, IRectangle b)
    {
        var horizontalCollision = a.X < b.X + b.Width && a.X + a.Width > b.X;
        var verticalCollision = a.Y < b.Y + b.Height && a.Y + a.Height > b.Y;
        return horizontalCollision && verticalCollision;
    }
    
    public static bool PointInRectangle(Point point, IRectangle rect)
    {
        return point.X >= rect.X && 
               point.X <= rect.X + rect.Width &&
               point.Y >= rect.Y && 
               point.Y <= rect.Y + rect.Height;
    }
}