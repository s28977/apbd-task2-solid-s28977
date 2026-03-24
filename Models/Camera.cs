namespace APBD_TASK2.Models;

public class Camera(string name, string brand, double aperture, int iso) : Equipment(name, brand)
{
    public double Aperture { get; } = aperture;
    public int Iso { get; } = iso;
    
    public override string ToString()
    {
        return $"Camera #{Id}: {Brand} {Name}, Aperture: f/{Aperture}, ISO: {Iso}, Available: {IsAvailable}";
    }
}