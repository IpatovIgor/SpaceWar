namespace Domain;
using Geometry;

public static class GameConfig
{
    public const int ScreenWidth = 1200;
    public const int ScreenHeight = 900;
    
    public static class Player
    {
        public const int Health = 500;
        public const int Speed = 7;
        public const int Score = 10;
        public static Size Size => new(85, 80);
        
        public const int BulletOffsetX = 29;
        public const int BulletOffsetUpY = -26;
        public const int BulletOffsetDownY = 90;
    }
    
    public static class Bullet
    {
        public const int Health = 5;
        public const int Speed = 9;
        public const int Damage = 5;
        public static Size Size => new(25, 25);
    }
    
    public static class Asteroid
    {
        public const int Health = 40;
        public const int Speed = 3;
        public const int Damage = 10;
        public const int Score = 5;
        public static Size Size => new(85, 85);
    }
    
    public static class Base
    {
        public const int Health = 700;
        public static Size Size => new(841, 500);
    }
    
    public static class Spawn
    {
        public const int Interval = 2;
        public const int MinX = 0;
        public const int MaxX = 1120;
        public const int StartY = 10;
    }

    public static bool IsInBounds(Position pos, Size size, bool allowPartialOutOfBounds = false)
    {
        if (allowPartialOutOfBounds)
        {
            return pos.X < ScreenWidth && 
                   pos.Y < ScreenHeight &&
                   pos.X + size.Width > 0 &&
                   pos.Y + size.Height > 0;
        }
        
        return pos.X >= 0 && 
               pos.Y >= 0 && 
               pos.X + size.Width <= ScreenWidth &&
               pos.Y + size.Height <= ScreenHeight;
    }
    
    public static class EnemyShip
    {
        public const int Health = 30;
        public const int Speed = 5;
        public const int Score = 10;
        public static Size Size => new(85, 80);
    }
}