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
    .AddSingleton<IDialogueManager, InMemoryDialogueManager>()
    .AddSingleton<INewUserHandler, NewUserHandler>()
    .AddSingleton<IVengeanceListManager, InMemoryVengeanceListManager>()
    .AddSingleton<ICommandAllHandler, CommandAllHandler>()
    .AddScoped<MainHandler>()
    .BuildServiceProvider();

var bot = provider.GetService<IBot>()!;

// ReSharper disable once UnusedParameter.Local
// ReSharper disable once VariableHidesOuterVariable
bot.OnMessageReceived += (bot, message) =>
{
    var scope = provider.CreateScope();
    
    scope.ServiceProvider.GetService<MainHandler>()!.Handle(bot, message);
};

bot.Start();

LogManager.Shutdown();





