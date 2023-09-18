namespace VengeanceListBot.Bot.Telegram;

public class TokenByConsoleUi : IToken
{
    public string Get()
    {
        Console.Write("Введите токен: ");
        return Console.ReadLine() ?? "";
    }
}