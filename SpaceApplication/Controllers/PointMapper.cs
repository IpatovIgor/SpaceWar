using Domain;
using Presentation;
using Point = System.Drawing.Point;

namespace SpaceApplication;

public class PointMapper
{
    public Point MapToPoint(GameObject gameObject)
    {
        return new Point
        {
            X = gameObject.RectPosition.X,
            Y = gameObject.RectPosition.Y,
        };
    }
}