using System.Collections;
using VengeanceListBot.Abstraction;

namespace VengeanceListBot.Implementation;

public class VengeanceList : IVengeanceList
{
    private readonly IList<Vengeance> _vengeanceList = new List<Vengeance>();

    public IEnumerator<Vengeance> GetEnumerator()
    {
        return _vengeanceList.GetEnumerator();
    }

    public void Add(Vengeance vengeance)
    {
        _vengeanceList.Add(vengeance);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}