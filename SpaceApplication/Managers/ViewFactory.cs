using Presentation;
using Domain;
using Geometry;
namespace SpaceApplication;

public class ViewFactory
{
    private readonly Dictionary<Type, Func<GameObject, IGameObjectView>> creators = new();
    
    public ViewFactory()
    {
        Register<Ship>(obj => new SpriteView(new Point(obj.RectPosition.X, obj.RectPosition.Y), "enemyShip.png"));
        Register<PlayerShip>(obj => new SpriteView(new Point(obj.RectPosition.X, obj.RectPosition.Y), "ship.png"));
        Register<Base>(obj => new SpriteView(new Point(obj.RectPosition.X, obj.RectPosition.Y), "spaceBase.png"));
        Register<Bullet>(obj => new SpriteView(new Point(obj.RectPosition.X, obj.RectPosition.Y), "bullet.png"));
        Register<Asteroid>(obj => new SpriteView(new Point(obj.RectPosition.X, obj.RectPosition.Y), "asteroid.png"));
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