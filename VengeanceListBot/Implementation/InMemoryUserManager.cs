using VengeanceListBot.Abstraction;

namespace VengeanceListBot.Implementation;

public class InMemoryUserManager : IUserManager
{
    private readonly ISet<long> _withWhoWeHaveDialogue = new HashSet<long>();

    public bool HasDialogueWith(long userId)
    {
        return _withWhoWeHaveDialogue.Contains(userId);
    }

    public void StartDialogueWith(long userId)
    {
        _withWhoWeHaveDialogue.Add(userId);
    }
}