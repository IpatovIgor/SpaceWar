using Raylib_cs;
namespace SpaceApplication;

public class StatController: IStatController
{
    public void AddScore(int score)
    {
        Score += score;
    }

    public void Print()
    {
        var text = $"Score: {Score}";
        Raylib.DrawText(text, 10, 10, 40, Color.White);
    }

    public int Score { get; private set; }
    
    public bool GameIsOver { get; set; }
}