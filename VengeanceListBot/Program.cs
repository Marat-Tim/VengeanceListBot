using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using VengeanceListBot;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;
using VengeanceListBot.Bot.Telegram;
using VengeanceListBot.Implementation;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var provider = new ServiceCollection()
    .AddLogging(builder =>
    {
        builder.ClearProviders();
        builder.SetMinimumLevel(LogLevel.Trace);
        builder.AddNLog("NLog.config");
    })
    .AddSingleton<IToken, TokenByConsoleUi>()
    .AddSingleton<IBot, Bot>()
    .AddSingleton<IUserManager, InMemoryUserManager>()
    .AddSingleton<INewUserHandler, NewUserHandler>()
    .AddSingleton<App>()
    .BuildServiceProvider();

provider.GetService<App>()!.Run();

LogManager.Shutdown();





