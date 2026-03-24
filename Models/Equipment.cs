namespace APBD_TASK2.Models;

public abstract class Equipment(string name, string brand)
{
    private static int _id = 1;
    public int Id { get; } = _id++;
    public string Name { get; set; } = name;
    public bool IsAvailable { get; set; } = true;
    public string Brand { get; set; } = brand;
}

