using VengeanceListBot.Bot;

namespace VengeanceListBot.Abstraction;

public interface INewUserHandler
{
    void Handle(IBot bot, Message message);
}