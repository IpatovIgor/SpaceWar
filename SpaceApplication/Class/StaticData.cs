using System.CodeDom.Compiler;

namespace SpaceApplication;

public static class StaticData
{
    public static readonly DataForObjects DataForMyShip;
    public static readonly DataForObjects DataForBase;

    static StaticData()
    {
        DataForMyShip = new DataForObjects(0, 650, 10000, 85, 80, "ship.png", 7);
        DataForBase = new DataForObjects(150, 700, 10000, 841, 500, "spaceBase.png", 7);
    }

    public static DataForObjects GenerateEnemyShip(int x, int y)
    {
        return new DataForObjects(x, y, 10, 85, 80, "ship.png", 7);
    }
    
    public static DataForObjects GenerateBullet(int x, int y)
    {
        return new DataForObjects(x, y, 10, 25, 25, "bullet.png", 9);
    }
    
    public static DataForObjects GenerateAsteroid(int x, int y)
    {
        return new DataForObjects(x, y, 20, 85, 85, "asteroid.png", 7);
    }
}