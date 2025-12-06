namespace Domain;

public interface IGameObjectRepository
{
    public void Add(GameObject obj);
    
    public void Remove(GameObject obj);
}