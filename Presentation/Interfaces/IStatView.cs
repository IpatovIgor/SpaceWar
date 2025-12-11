namespace Presentation;

public interface IStatView
{
    public void UpdateStats(int score, int playerHP, int baseHP, bool gameOver);

    public void Draw();
    
    
}