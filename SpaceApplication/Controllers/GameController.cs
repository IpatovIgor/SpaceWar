using Domain;
using Presentation;
using Geometry;

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
        var playerShip = new PlayerShip(
            inputForPlayerShip, 
            new Position(0, 650),
            GameConfig.Player.Size,
            new Health(GameConfig.Player.Health),
            new Speed(GameConfig.Player.Speed), 
            repository, 
            Direction.Up);
        
        var back = new Background("space.png", 0, 0);

        var @base = new Base(
            new StopInput(), 
            new Position(150, 700),
            GameConfig.Base.Size,
            new Health(GameConfig.Base.Health),
            new Speed(GameConfig.Player.Speed),
            repository, 
            Direction.Up);

        var statView = new StatView();
        
        playerShip.RegisterInRepository();
        @base.RegisterInRepository();

        while (!Raylib.WindowShouldClose())
        {
            statView.UpdateStats(world.statController.AllScore.Value, world.statController.PlayerHP.Value,
                world.statController.BaseHP.Value, world.statController.GameIsOver);
            var deltaTime = Raylib.GetFrameTime();
            
            spawner.TrySpawn(deltaTime);
            world.UpdateAllObjects();
            viewManager.UpdateViewers();
            
            Draw(back, statView, deltaTime);
            
            if (world.statController.GameIsOver)
                break;
        }
        
        back.Dispose();
        return world.statController.AllScore.Value;
    }

    private void Draw(Background backTexture, IStatView statView, float deltaTime)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        backTexture.Draw();
        statView.Draw();
        renderer.Render(viewManager.ViewsObjects);
        Raylib.EndDrawing();
    }
}