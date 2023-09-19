namespace VengeanceListBot.Abstraction;

public interface IVengeanceListManager
{
    IVengeanceList GetVengeanceListForUser(long userId);
}