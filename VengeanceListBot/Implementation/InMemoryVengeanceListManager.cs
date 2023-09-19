using VengeanceListBot.Abstraction;

namespace VengeanceListBot.Implementation;

public class InMemoryVengeanceListManager : IVengeanceListManager
{
    private readonly IDictionary<long, IVengeanceList> _userToVengeanceList = 
        new Dictionary<long, IVengeanceList>();

    public IVengeanceList GetVengeanceListForUser(long userId)
    {
        if (!_userToVengeanceList.ContainsKey(userId))
        {
            _userToVengeanceList.Add(userId, new VengeanceList());
        }
        return _userToVengeanceList[userId];
    }
}