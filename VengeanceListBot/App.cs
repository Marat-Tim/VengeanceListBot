using Microsoft.Extensions.Logging;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot;

public class App
{
    private readonly IBot _bot;

    private readonly ILogger<App> _logger;

    private readonly INewUserHandler _newUserHandler;

    public App(IBot bot, ILogger<App> logger, INewUserHandler newUserHandler)
    {
        _logger = logger;
        _bot = bot;
        _newUserHandler = newUserHandler;
    }

    public void Run()
    {
        _bot.OnMessageReceived += _newUserHandler.Handle;
        _bot.OnMessageReceived += WriteLog;
        _bot.Start();
    }

    private void WriteLog(IBot bot, Message message)
    {
        _logger.LogDebug($"Получено сообщение {message}");
    }
}