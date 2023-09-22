using System.Collections;
using System.Text;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

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

    public void SendToUser(IBot bot, long userId)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"Текущий список отмщений:{Environment.NewLine}");
        int i = 1;
        foreach (var vengeance in this)
        {
            sb.Append($"{i}. {vengeance.Name}{Environment.NewLine}");
            ++i;
        }

        if (i == 1)
        {
            sb.Append("Пусто");
        }

        bot.Send(userId, sb.ToString());
    }

    public void NotifyUser(IBot bot, long userId)
    {
        foreach (var vengeance in this)
        {
            bot.Send(userId, vengeance.ToString());
            Thread.Sleep(Constants.TimeBetweenMessages);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}