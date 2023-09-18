namespace VengeanceListBot.Bot;

public record Message(long Id, User User, Chat Chat, string Text);