using Microsoft.Extensions.Logging;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot;

public class App
{
    private readonly IBot _bot;

    private readonly ILogger<App> _logger;

    private readonly IUserManager _userManager;

    private readonly INewUserHandler _newUserHandler;

    public App(IBot bot,
        ILogger<App> logger, 
        INewUserHandler newUserHandler,
        IUserManager userManager)
    {
        _logger = logger;
        _bot = bot;
        _newUserHandler = newUserHandler;
        _userManager = userManager;
    }

    public void Run()
    {
        _bot.OnMessageReceived += HandleOnlyNewUsersFromPrivateChats(_newUserHandler.Handle);
        _bot.OnMessageReceived += WriteLog;
        _bot.Start();
    }

    private void WriteLog(IBot bot, Message message)
    {
        _logger.LogDebug($"Получено сообщение {message}");
    }

    private Action<IBot, Message> HandleOnlyNewUsersFromPrivateChats(Action<IBot, Message> handler)
    {
        void Wrapped(IBot bot, Message message)
        {
            var userId = message.User.Id;
            if (!_userManager.HasDialogueWith(userId) && !message.Chat.IsGroup)
            {
                _userManager.StartDialogueWith(userId);
                handler(bot, message);
            }
        }
    }
}