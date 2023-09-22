using VengeanceListBot.Bot;

namespace VengeanceListBot.Abstraction;

public interface IVengeanceList : IEnumerable<Vengeance>
{
    void Add(Vengeance vengeance);

    void SendToUser(IBot bot, long userId);

    void NotifyUser(IBot bot, long userId);
}