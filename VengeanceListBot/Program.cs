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
    .AddSingleton<ICommandAddHandler, CommandAddHandler>()
    .AddSingleton<IAnnunciator, Annunciator>()
    .AddScoped<MainHandler>()
    .BuildServiceProvider();

StartNotification(provider);
StartHandleMessages(provider);

LogManager.Shutdown();

void StartNotification(ServiceProvider serviceProvider)
{
    serviceProvider.GetService<IAnnunciator>()!.Start();
}

void StartHandleMessages(ServiceProvider serviceProvider)
{
    var bot = serviceProvider.GetService<IBot>()!;

    // ReSharper disable once UnusedParameter.Local
    // ReSharper disable once VariableHidesOuterVariable
    bot.OnMessageReceived += (bot, message) =>
    {
        var scope = serviceProvider.CreateScope();

        scope.ServiceProvider.GetService<MainHandler>()!.Handle(bot, message);
    };

    bot.Start();
}





