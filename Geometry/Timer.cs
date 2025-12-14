namespace Geometry;

public class Timer
{
    private float _currentTime;
    private float _interval;
    
    public Timer(float intervalInSeconds)
    {
        _interval = intervalInSeconds;
        _currentTime = 0f;
    }
    
    public bool Update(float deltaTime)
    {
        _currentTime += deltaTime;
        
        if (_currentTime >= _interval)
        {
            _currentTime = 0f;
            return true; // Таймер сработал
        }
        
        return false;
    }
    
    public void Reset()
    {
        _currentTime = 0f;
    }
}