namespace VengeanceListBot.Abstraction;

public interface IDialogueManager
{
    bool HasDialogueWith(long userId);

    void StartDialogueWith(long userId);
}