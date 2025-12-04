using Raylib_cs;

namespace SpaceApplication;

public class KeyBoardInput:IGameInput
{
    private bool pressFlag = true;
    
    public List<GameEvents> GetEvents()
    {
        var eventsList = new List<GameEvents>();
        if (Raylib.IsKeyDown(KeyboardKey.D))
            eventsList.Add(GameEvents.MoveRight);
        if (Raylib.IsKeyDown(KeyboardKey.A))
            eventsList.Add(GameEvents.MoveLeft);
        if (Raylib.IsKeyPressed(KeyboardKey.Space))
            eventsList.Add(GameEvents.Shoot);

        return eventsList;
    }
}