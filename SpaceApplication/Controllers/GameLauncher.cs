using Domain;
namespace SpaceApplication;

public class GameLauncher
{
    public void LaunchGame()
    {
        var game = CreateGame();
        game.StartGame();
    }
    
    private GameController CreateGame()
    {
        var world = new GameWorld();
        var input = new KeyBoardInput();
        var repository = new GameObjectRepository(world);
        var spawner = new Spawner(world, repository);
        var viewManager = new ViewManager(world);
        var renderer = new GameRenderer();
        var mapper = new PointMapper();
        
        return new GameController(world, input, viewManager, spawner, repository, renderer, mapper);
    }
}