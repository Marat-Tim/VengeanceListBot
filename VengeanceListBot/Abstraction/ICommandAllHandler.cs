using VengeanceListBot.Bot;

namespace VengeanceListBot.Abstraction;

public interface ICommandAllHandler
{
    void Handle(IBot bot, Message message);
}