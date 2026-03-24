namespace APBD_TASK2.Models;

public class Projector(string name, string brand, int brightness, int contrastRatio) : Equipment(name, brand)
{
    public int Brightness { get; set; } = brightness;
    public int ContrastRatio { get; set; } = contrastRatio;
    
    public override string ToString()
    {
        return $"Projector #{Id}: {Brand} {Name}, Brightness: {Brightness} lm, Contrast Ratio: {ContrastRatio}, Available: {IsAvailable}";
    }
}