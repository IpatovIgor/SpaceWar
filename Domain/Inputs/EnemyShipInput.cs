namespace Domain;

public class EnemyShipInput: IGameInput
{
    private Timer timer = new Timer(1);
    private GameEvents lastEvent = GameEvents.MoveRight;
    public List<GameEvents> GetEvents()
    {
        var random = new Random();
        var deltaTime = 0.01f;
        if (timer.Update(deltaTime))
        {
             lastEvent = (GameEvents)random.Next(0, 3);
        }
        else
        {
            if (lastEvent == GameEvents.Shoot)
            {
                lastEvent = (GameEvents)random.Next(0, 3);
                timer.Reset();
            }
        }
        
        return new List<GameEvents>() { lastEvent };
    }
}