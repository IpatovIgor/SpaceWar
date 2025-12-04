using System.Xml;
using Domain;
using Raylib_cs;

namespace SpaceApplication;

public class Bullet: GameObject
{
    public Bullet(IGameInput input, DataForObjects data, List<GameObject> list) :
        base(input, data, list)
    {
        texture = Raylib.LoadTexture("bullet.png");
    }

    private void HitShips()
    {
        for (var i = 0; i < objList.Count; i++)
        {
            if (objList[i].Equals(this))
                continue;
            
            if (Collisions.TwoRectHaveCollisions(this, objList[i]))
            {
                objList[i].GetDamage(10);    
                GetDamage(10);
            }
            
        }
    }

    public override bool Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveUp)
                MoveUp();
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        if (Y < 20 || HP <= 0 || Y > 900)
            Die();
        HitShips();
        Print();
        return false;
    }
}