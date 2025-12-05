using Domain;
namespace SpaceApplication.Class;

public class ViewFactory
{
    private readonly Dictionary<Type, Func<GameObject, IGameObjectView>> creators = new();
    
    public ViewFactory()
    {
        Register<Ship>(obj => new ShipView((Ship)obj, "ship.png"));
        Register<PlayerShip>(obj => new PlayerShipView((Ship)obj, "ship.png"));
        Register<Base>(obj => new BaseView((Base)obj, "spaceBase.png"));
        Register<Bullet>(obj => new BulletView((Bullet)obj, "bullet.png"));
        Register<Asteroid>(obj => new AsteroidView((Asteroid)obj, "asteroid.png"));
    }
    
    private void Register<T>(Func<GameObject, IGameObjectView> creator) where T : GameObject
    {
        creators[typeof(T)] = creator;
    }
    
    public IGameObjectView CreateView(GameObject gameObject)
    {
        var type = gameObject.GetType();
        
        if (creators.TryGetValue(type, out var exactCreator))
        {
            return exactCreator(gameObject);
        }
        
        var baseType = type.BaseType;
        while (baseType != null && baseType != typeof(object))
        {
            if (creators.TryGetValue(baseType, out var baseCreator))
            {
                return baseCreator(gameObject);
            }
            baseType = baseType.BaseType;
        }
    
        throw new InvalidOperationException($"No view creator for type {gameObject.GetType()}");
    }
}