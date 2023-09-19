namespace VengeanceListBot;

public record Vengeance(string Name)
{
    public override string ToString()
    {
        return Name;
    }
}