namespace APBD_TASK2.Models;

public class Projector(string name, string brand, int brightness, int contrastRation) : Equipment(name, brand)
{
    public int Brightness{ get; set; }
    public int ContrastRatio { get; set; }
}