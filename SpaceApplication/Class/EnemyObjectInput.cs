namespace SpaceApplication;

public class EnemyObjectInput:IGameInput
{
    public List<GameEvents> GetEvents()
    {
        return new List<GameEvents>() { GameEvents.MoveDown };
    }
}