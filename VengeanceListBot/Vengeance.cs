using System.Security.AccessControl;

namespace VengeanceListBot;

public record Vengeance(string Name)
{
    public DateTime StartDate { get; } = DateTime.Now; 

    public override string ToString()
    {
        return $"День {(DateTime.Now - StartDate).Days}. {Name} ещё не отмщен";
    }
}