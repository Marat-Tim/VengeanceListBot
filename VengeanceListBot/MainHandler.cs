using Microsoft.Extensions.Logging;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot;

public class MainHandler
{
    private readonly ILogger<MainHandler> _logger;

    private readonly IDialogueManager _dialogueManager;

    private readonly INewUserHandler _newUserHandler;

    public MainHandler(ILogger<MainHandler> logger, 
        INewUserHandler newUserHandler,
        IDialogueManager dialogueManager)
    {
        _logger = logger;
        _newUserHandler = newUserHandler;
        _dialogueManager = dialogueManager;
    }

    public void Handle(IBot bot, Message message)
    {
        HandleIfNewUser(bot, message);
        WriteLog(message);
    }

    private void HandleIfNewUser(IBot bot, Message message)
    {
        var userId = message.User.Id;
        if (!_dialogueManager.HasDialogueWith(userId) && !message.Chat.IsGroup)
        {
            _newUserHandler.Handle(bot, message);
            _dialogueManager.StartDialogueWith(userId);
        }
    }

    private void WriteLog(Message message)
    {
        _logger.LogDebug($"Получено сообщение {message}");
    }
}