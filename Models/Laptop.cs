namespace APBD_TASK2.Models;

public class Laptop(string name, string brand, string cpu, int ram) : Equipment(name, brand)
{
    public string Cpu { get; } = cpu;
    public int Ram { get; } = ram;
    public override string ToString()
    {
        return $"Laptop #{Id}: {Brand} {Name}, CPU: {Cpu}, RAM: {Ram} GB, Available: {IsAvailable}";
    }
}