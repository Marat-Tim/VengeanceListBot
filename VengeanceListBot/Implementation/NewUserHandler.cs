using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class NewUserHandler : INewUserHandler
{
    private readonly IVengeanceListManager _vengeanceListManager;

    public NewUserHandler(IVengeanceListManager vengeanceListManager)
    {
        _vengeanceListManager = vengeanceListManager;
    }

    public void Handle(IBot bot, Message message)
    {
        var chatId = message.Chat.Id;
        bot.Send(chatId, Constants.Greeting);
        _vengeanceListManager.GetVengeanceListForUser(message.User.Id).SendToUser(bot, chatId);
    }
    
}