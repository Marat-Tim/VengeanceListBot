namespace VengeanceListBot.Bot;

public interface IBot
{
    event Action<IBot, Message> OnMessageReceived;

    Message Send(long chatId, string text);

    void Start();
}