namespace Presentation;
using Raylib_cs;

public class StatView : IStatView
{
    private readonly Font font;
    private int score = 0;
    private int playerHP = 100;
    private int baseHP = 100;
    private bool gameOver = false;
    
    public StatView()
    {
        font = Raylib.GetFontDefault();
    }
    
    public void UpdateStats(int score, int playerHP, int baseHP, bool gameOver)
    {
        this.score = score;
        this.playerHP = playerHP;
        this.baseHP = baseHP;
        this.gameOver = gameOver;
    }
    
    public void Draw()
    {
        Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.White);
        Raylib.DrawText($"Player: {playerHP} HP", 10, 40, 20, GetHealthColor(playerHP, 100));
        Raylib.DrawText($"Base: {baseHP} HP", 10, 70, 20, GetHealthColor(baseHP, 500));
    }
    
    private Color GetHealthColor(int current, int max)
    {
        float percent = (float)current / max;
        return percent switch
        {
            > 0.5f => Color.Green,
            > 0.25f => Color.Yellow,
            _ => Color.Red
        };
    }
    
    public void Dispose() { }
}