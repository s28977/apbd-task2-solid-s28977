namespace APBD_TASK2.Models;

public class Laptop(string name, string brand, string cpu, int ram) : Equipment(name, brand)
{
    public string Cpu { get; set; } = cpu;
    public int Ram { get; set; } = ram;
}