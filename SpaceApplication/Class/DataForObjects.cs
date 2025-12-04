namespace SpaceApplication;

public class DataForObjects
{
    public DataForObjects(int x, int y, int hp, int w, int h, string imagePath, int speed)
    {
        X = x;
        Y = y;
        HP = hp;
        W = w;
        H = h;
        ImagePath = imagePath;
        Speed = speed;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
    public int HP { get; private set; }
    public int W { get; private set; }
    public int H { get; private set; }
    public int Speed { get; private set; }
    public string ImagePath{ get; private set; }
    
}