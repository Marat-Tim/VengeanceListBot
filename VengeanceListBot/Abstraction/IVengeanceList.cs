namespace VengeanceListBot.Abstraction;

public interface IVengeanceList : IEnumerable<Vengeance>
{
    void Add(Vengeance vengeance);
}