namespace Geometry;

public static class Collisions
{
    public static bool TwoRectHaveCollisions(IRectangle a, IRectangle b)
    {
        var horizontalCollision = a.RectPosition.X < b.RectPosition.X + b.RectSize.Width 
                                  && a.RectPosition.X + a.RectSize.Width > b.RectPosition.X;
        var verticalCollision = a.RectPosition.Y < b.RectPosition.Y + b.RectSize.Height
                                && a.RectPosition.Y + a.RectSize.Height > b.RectPosition.Y;
        return horizontalCollision && verticalCollision;
    }
    
    public static bool PointInRectangle(Point point, IRectangle rect)
    {
        return point.X >= rect.RectPosition.X && 
               point.X <= rect.RectPosition.X + rect.RectSize.Width &&
               point.Y >= rect.RectPosition.Y && 
               point.Y <= rect.RectPosition.Y + rect.RectSize.Height;
    }
}