namespace VengeanceListBot.Bot;

public interface IBot
{
    event Action<IBot, Message> OnMessageReceived;

    Message Send(long id, string text);

    void Start();
}