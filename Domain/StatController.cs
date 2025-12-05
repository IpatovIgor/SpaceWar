namespace Domain;

public class StatController: IStatController
{
    public void AddScore(int score)
    {
        Score += score;
    }
    
    public int Score { get; private set; }
    
    public bool GameIsOver { get; set; }
}