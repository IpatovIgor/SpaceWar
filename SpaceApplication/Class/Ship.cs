using System.Xml;
using Domain;
using Raylib_cs;

namespace SpaceApplication;

public class Ship : GameObject, IGiveScore
{
    public Ship(IGameInput input, DataForObjects data, List<GameObject> list, GameEvents dir) 
        : base(input, data, list)
    {
        Score = 10;
        if (dir != GameEvents.MoveDown && dir != GameEvents.MoveUp)
            throw new Exception("Нельзя такое направление прокидывать");
        Console.WriteLine($"Текущая директория: {Directory.GetCurrentDirectory()}");
        direction = dir;
    }
    
    private GameEvents direction;

    private void Shoot()
    {
        if (direction == GameEvents.MoveUp)
            new Bullet(new BulletInput(direction), StaticData.GenerateBullet(X + 29, Y - 26), objList);
        else
            new Bullet(new BulletInput(direction), StaticData.GenerateBullet(X + 29, Y + 90), objList);
    }
    
    public override bool Update()
    {
        var eventsList = input.GetEvents();
        foreach (var gameEvent in eventsList)
        {
            switch (gameEvent)
            {
                case GameEvents.MoveLeft:
                    MoveLeft();
                    break;
                case GameEvents.MoveRight:
                    MoveRight();
                    break;
                case GameEvents.MoveUp:
                    MoveUp();
                    break;
                case GameEvents.MoveDown:
                    MoveDown();
                    break;
                case GameEvents.Shoot:
                    Shoot();
                    break;
            }
        }

        var wasDie = false;

        if (HP <= 0 || Y > 800)
        {
            Die();
            wasDie = true;
        }

        Print();
        return wasDie;
    }
    
    public int Score { get; }
}