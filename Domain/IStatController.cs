using System.Dynamic;

namespace Domain;

public interface IStatController
{
    public void AddScore(int score);
    
    public int Score { get; }
    
    public bool GameIsOver { get; set; }
}