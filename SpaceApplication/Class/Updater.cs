/*namespace SpaceApplication;

public class Updater(List<GameObject> list, IStatController stat) : IUpdater
{
    private bool ParseAndCheckToDie<T>(GameObject obj) 
        where T : class
    {
        if (obj is not T castTo) return false;
        stat.GameIsOver = true;
        return false;

    }
    
    private void TryGiveScore(GameObject obj)
    {
        if (obj is not IGiveScore castToScore)
            return;
        
        if (ParseAndCheckToDie<MyShip>(obj))
            return;
        if (ParseAndCheckToDie<Base>(obj))
            return;
        ParseAndCheckToDie<Base>(obj);
            
        stat.AddScore(castToScore.Score);
    }

    public void UpdateAllObjects(IStatController statController)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var obj = list[i];
            var die = list[i].Update();
            if (die)
                TryGiveScore(obj);
        }
    }
}*/