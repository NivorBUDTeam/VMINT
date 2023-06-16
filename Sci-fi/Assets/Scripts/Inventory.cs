public class Inventory
{
    public static Inventory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
    }

    private static Inventory _instance;

    public int ShotsCounter { get; set; }
}
