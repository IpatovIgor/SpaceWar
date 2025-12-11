// Domain/Services/StatController.cs
namespace Domain;

public class StatController : IStatController
{
    public StatController()
    {
        AllScore = new Score(0);
        PlayerHP = new Health(100);
        BaseHP = new Health(100);
    }
    
    public Score AllScore { get; private set; }
    public Health PlayerHP { get; private set; }
    public Health BaseHP { get; private set; }
    public bool GameIsOver { get; private set; }
    
    public void AddScore(int score)
    {
        if (score < 0) throw new Exception("Score cannot be negative");
        AllScore = new Score(score + AllScore.Value);
    }

    public void UpdatePlayerHP(int hp)
    {
        PlayerHP = new Health(hp);
        if (PlayerHP.Value <= 0)
            GameIsOver = true;
    }
    
    public void UpdateBaseHP(int hp)
    {
        BaseHP = new Health(hp);
        if (BaseHP.Value <= 0)
            GameIsOver = true;
    }
    
    public void Reset()
    {
        AllScore = new Score(0);
        PlayerHP = new Health(100);
        BaseHP = new Health(100);
        GameIsOver = false;
    }
}