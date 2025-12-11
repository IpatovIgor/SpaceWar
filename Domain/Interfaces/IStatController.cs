using System.Dynamic;

namespace Domain;

public interface IStatController
{
    public void AddScore(int score);
    
    public Score AllScore { get; }
    public Health PlayerHP { get; }
    public Health BaseHP { get; }
    public bool GameIsOver { get; }

    public void UpdatePlayerHP(int hp);

    public void UpdateBaseHP(int hp);

    public void Reset();

}