using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class CommandAddHandler : ICommandAddHandler
{
    private readonly IVengeanceListManager _vengeanceListManager;

    private readonly ICommandAllHandler _commandAllHandler;

    public CommandAddHandler(IVengeanceListManager vengeanceListManager,
        ICommandAllHandler commandAllHandler)
    {
        _vengeanceListManager = vengeanceListManager;
        _commandAllHandler = commandAllHandler;
    }

    public async Task Handle(IBot bot, Message message)
    {
        var chatId = message.Chat.Id;
        var vengeanceList = _vengeanceListManager.GetVengeanceListForUser(message.User.Id);
        bot.Send(chatId, "Ввведите имя человека, которого нужно добавить в список отмщений");
        var reply = await bot.WaitForMessage(msg => msg.Chat.Id == chatId);
        vengeanceList.Add(new Vengeance(reply.Text));
        bot.Send(chatId, "Отмщение успешно добавлено");
        _commandAllHandler.Handle(bot, message);
    }
}