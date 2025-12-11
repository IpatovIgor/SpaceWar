using Domain;
using Presentation;

namespace SpaceApplication;
using Raylib_cs;

public class GameController: IGameController
{
    private GameWorld world;
    private IGameInput inputForPlayerShip;
    private ViewManager viewManager;
    private ISpawner spawner;
    private IGameObjectRepository repository;
    private GameRenderer renderer;
    private PointMapper mapper;
    
    public GameController(
        GameWorld world,
        IGameInput input,
        ViewManager viewManager,
        ISpawner spawner,
        IGameObjectRepository repository,
        GameRenderer renderer,
        PointMapper mapper
        )
    {
        this.mapper = mapper;
        this.renderer = renderer;
        this.world = world;
        inputForPlayerShip = input;
        this.viewManager = viewManager;
        this.spawner = spawner;
        this.repository = repository;
    }
    
    public int StartGame()
    {
        var playerShip = new PlayerShip(inputForPlayerShip, new Position(0, 650),
            new Size(85, 80), new Health(1000), new Speed(7), repository, Direction.Up);
        var backTexture = Raylib.LoadTexture("space.png");
        var @base = new Base(new StopInput(), new Position(150, 700),
            new Size(841, 500), new Health(1000), new Speed(7), repository, Direction.Up);
        var statView = new StatView();

        while (!Raylib.WindowShouldClose())
        {
            statView.UpdateStats(world.statController.AllScore.Value, world.statController.PlayerHP.Value,
                world.statController.BaseHP.Value, world.statController.GameIsOver);
            var deltaTime = Raylib.GetFrameTime();
            
            Draw(backTexture, statView, deltaTime);
            
            if (world.statController.GameIsOver)
                break;
        }
        
        Raylib.UnloadTexture(backTexture);
        return world.statController.AllScore.Value;
    }

    private void Draw(Texture2D backTexture, IStatView statView, float deltaTime)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        Raylib.DrawTexture(backTexture, 0, 0, Color.White);
        statView.Draw();
        spawner.TrySpawn(deltaTime);
        world.UpdateAllObjects();
        viewManager.UpdateViewers();
        renderer.Render(viewManager.ViewsObjects);
        Raylib.EndDrawing();
    }
}