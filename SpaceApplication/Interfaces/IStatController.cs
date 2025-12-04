using System.Dynamic;

namespace SpaceApplication;

public interface IStatController
{
    public void AddScore(int score);

    public void Print();

    public int Score { get; }
    
    public bool GameIsOver { get; set; }
}