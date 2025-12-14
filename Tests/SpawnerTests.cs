using Domain;
using Moq;
using Domain;
using Geometry;
using NUnit.Framework;

[TestFixture]
public class SpawnerTests
{
    [Test]
    public void Spawner_TrySpawn_WhenTimerNotReady_DoesNotSpawn()
    {
        var mockWorld = new Mock<GameWorld>();
        var mockRepository = new Mock<IGameObjectRepository>();
        var spawner = new Spawner(mockWorld.Object, mockRepository.Object);

        spawner.TrySpawn(0.5f);

        mockRepository.Verify(r => r.Add(It.IsAny<GameObject>()), Times.Never);
    }
    
    [Test]
    public void Spawner_TrySpawn_WhenTimerReady_SpawnsObjects()
    {
        var mockWorld = new Mock<GameWorld>();
        mockWorld.Setup(w => w.CheckCollisionWithObject(It.IsAny<GameObject>()))
            .Returns(false);
        
        var mockRepository = new Mock<IGameObjectRepository>();
        var spawner = new Spawner(mockWorld.Object, mockRepository.Object);

        spawner.TrySpawn(2.5f);
        
        mockRepository.Verify(r => r.Add(It.IsAny<GameObject>()), Times.AtLeastOnce);
    }
    
    [Test]
    public void Spawner_Spawn_WhenCollisionExists_DoesNotAddObject()
    {
        var mockWorld = new Mock<GameWorld>();
        mockWorld.Setup(w => w.CheckCollisionWithObject(It.IsAny<GameObject>()))
            .Returns(true);
        
        var mockRepository = new Mock<IGameObjectRepository>();
        var spawner = new Spawner(mockWorld.Object, mockRepository.Object);
        
        mockRepository.Verify(r => r.Add(It.IsAny<GameObject>()), Times.Never);
    }
}