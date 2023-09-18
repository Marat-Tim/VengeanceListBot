using Microsoft.VisualBasic;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class NewUserHandler : INewUserHandler
{

    public void Handle(IBot bot, Message message)
    {
        var chatId = message.Chat.Id;
        bot.Send(chatId, Constants.Greeting);

    }
    
}