using VengeanceListBot.Bot;

namespace VengeanceListBot.Abstraction;

public interface ICommandAddHandler
{
    Task Handle(IBot bot, Message message);
}