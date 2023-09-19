namespace VengeanceListBot;

public static class Constants
{
    public const string Greeting = @"Привет, я бот, помогающий вести список отмщений

Команды:
/add - чтобы добавить нового человека в список
/all - чтобы посмотреть на текущий список отмщений";

    public static readonly TimeSpan TimeBetweenNotifications = TimeSpan.FromDays(1);
}