namespace Ferrari.Interfaces
{
    public interface Car
    {
        string Make { get; }
        string Model { get; }
        string Brakes();
        string GasPedal();
    }
}
