using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VengeanceListBot.Bot.Telegram;

public class Bot : IBot
{

    private readonly TelegramBotClient _client;

    private readonly ILogger _logger;

    public Bot(IToken token, ILogger<Bot> logger)
    {
        _client = new TelegramBotClient(token.Get());
        _logger = logger;
        _logger.LogTrace("Test");
    }

    public event Action<IBot, Message>? OnMessageReceived;

    public Message Send(long chatId, string text)
    {
        var message = _client.SendTextMessageAsync(chatId, text).Result;
        return MapTelegramMessageToOurMessage(message);
    }

    public void Start()
    {
        var cts = new CancellationTokenSource();
        var token = cts.Token;
        _client.StartReceiving(UpdateHandler, PollingErrorHandler, new ReceiverOptions(), token);
        _logger.LogInformation("Бот начал работу");
        token.WaitHandle.WaitOne();
    }

    private void PollingErrorHandler(ITelegramBotClient bot, 
        Exception exception, 
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    private void UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        if (update is {Type: UpdateType.Message, Message.From: not null})
        {
            OnMessageReceived?.Invoke(this, MapTelegramMessageToOurMessage(update.Message!));
        }
    }

    private Message MapTelegramMessageToOurMessage(global::Telegram.Bot.Types.Message message)
    {
        return new Message(
            message.MessageId,
            new User(message.From!.Id),
            new Chat(message.Chat.Id, message.Chat.IsForum ?? false),
            message.Text ?? ""
            );
    }
}