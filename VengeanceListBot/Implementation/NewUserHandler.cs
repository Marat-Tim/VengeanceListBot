using Microsoft.VisualBasic;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class NewUserHandler : INewUserHandler
{
    private readonly IUserManager _userManager;

    public NewUserHandler(IUserManager userManager)
    {
        _userManager = userManager;
    }

    public void Handle(IBot bot, Message message)
    {
        if (!message.Chat.IsGroup && !_userManager.HasDialogueWith(message.User.Id))
        {
            StartDialogueWithUser(bot, message);
        }
    }

    private void StartDialogueWithUser(IBot bot, Message message)
    {
        _userManager.StartDialogueWith(message.User.Id);
        bot.Send(message.Chat.Id, Constants.Greeting);
    }
}