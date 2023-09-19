using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class NewUserHandler : INewUserHandler
{
    private readonly IVengeanceListManager _vengeanceListManager;

    private readonly ICommandAllHandler _commandAllHandler;

    public NewUserHandler(IVengeanceListManager vengeanceListManager, ICommandAllHandler commandAllHandler)
    {
        _vengeanceListManager = vengeanceListManager;
        _commandAllHandler = commandAllHandler;
    }

    public void Handle(IBot bot, Message message)
    {
        var chatId = message.Chat.Id;
        bot.Send(chatId, Constants.Greeting);
        _commandAllHandler.Handle(bot, message);
    }
    
}