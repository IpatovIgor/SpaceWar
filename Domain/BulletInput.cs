namespace Domain;

public class BulletInput: IGameInput
{
    public BulletInput(Direction dirEvent)
    {
        dir = dirEvent;
    }

    private Direction dir;
    
    public List<GameEvents> GetEvents()
    {
        if (dir == Direction.Up)
            return new List<GameEvents>() {GameEvents.MoveUp};
        return new List<GameEvents>() {GameEvents.MoveDown};
    }
}