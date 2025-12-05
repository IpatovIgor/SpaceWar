namespace SpaceApplication;

public class Program
{
    public static void Main()
    {
        var input = new KeyBoardInput();
        var game = new GameController(input);
        game.StartGame();
    }
}