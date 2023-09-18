namespace VengeanceListBot.Abstraction;

public interface IUserManager
{
    bool HasDialogueWith(long userId);

    void StartDialogueWith(long userId);
}