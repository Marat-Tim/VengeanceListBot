using Telegram.Bot.Types;

namespace VengeanceListBot.Bot;

public static class BotExtensions
{
    /// <summary>
    /// Ожидает и возвращает сообщение, подходящее под заданный предикат.
    /// <br></br>
    /// Данный метод нужен, для удобства создания диалогов
    /// </summary>
    /// <param name="bot">Экземпляр бота</param>
    /// <param name="predicate">Какое сообщение нужно ожидать</param>
    /// <returns>Первое сообщение, подходящее под заданный предикат</returns>
    public static Task<Message> WaitForMessage(this IBot bot, Predicate<Message> predicate)
    {
        TaskCompletionSource<Message> taskCompletionSource =
            new TaskCompletionSource<Message>();

        // ReSharper disable once VariableHidesOuterVariable
        void Wrapped(IBot bot, Message message)
        {
            if (predicate(message))
            {
                taskCompletionSource.SetResult(message);
                bot.OnMessageReceived -= Wrapped;
            }
        }

        bot.OnMessageReceived += Wrapped;

        return taskCompletionSource.Task;
    }
}