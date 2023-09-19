using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class CommandAllHandler : ICommandAllHandler
{
    private readonly IVengeanceListManager _vengeanceListManager;

    public CommandAllHandler(IVengeanceListManager vengeanceListManager)
    {
        _vengeanceListManager = vengeanceListManager;
    }

    public void Handle(IBot bot, Message message)
    {
        _vengeanceListManager.GetVengeanceListForUser(message.User.Id)
            .SendToUser(bot, message.Chat.Id);
    }
}