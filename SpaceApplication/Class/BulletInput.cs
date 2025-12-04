namespace SpaceApplication;

public class BulletInput: IGameInput
{
    public BulletInput(GameEvents dirEvent)
    {
        if (dirEvent != GameEvents.MoveDown && dirEvent != GameEvents.MoveUp)
            throw new Exception("Нельзя закидывать такое");
        dir = dirEvent;
    }

    private GameEvents dir;
    
    public List<GameEvents> GetEvents()
    {
        if (dir == GameEvents.MoveUp)
            return new List<GameEvents>() {GameEvents.MoveUp};
        return new List<GameEvents>() {GameEvents.MoveDown};
    }
}