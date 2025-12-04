using Domain;
using Raylib_cs;
namespace SpaceApplication;

public class Asteroid: GameObject, IGiveScore
{
    public Asteroid(IGameInput input, DataForObjects data, List<GameObject> list) 
        : base(input, data, list)
    {
        Score = 5;
    }
    
    public void HitShips()
    {
        for (var i = 0; i < objList.Count; i++)
        {
            if (objList[i].Equals(this))
                continue;
            
            if (Collisions.TwoRectHaveCollisions(this, objList[i]))
            {
                objList[i].GetDamage(10);    
                GetDamage(20);
            }
        }
    }

    public override bool Update()
    {
        foreach (var gameEvent in input.GetEvents())
        {
            if (gameEvent == GameEvents.MoveDown)
                MoveDown();
        }
        
        HitShips();
        bool wasDie = HP <= 0;
        if (Y > 900 || HP <= 0)
            Die();
        
        Print();
        return wasDie;
    }

    public int Score { get; }
}