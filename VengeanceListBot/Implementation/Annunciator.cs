using Microsoft.Extensions.Logging;
using VengeanceListBot.Abstraction;
using VengeanceListBot.Bot;

namespace VengeanceListBot.Implementation;

public class Annunciator : IAnnunciator, IDisposable
{
    private Timer? _timer;

    private readonly IDialogueManager _dialogueManager;

    private readonly IVengeanceListManager _vengeanceListManager;

    private readonly IBot _bot;
    private readonly ILogger<Annunciator> _logger;

    public Annunciator(IDialogueManager dialogueManager,
        IVengeanceListManager vengeanceListManager,
        IBot bot,
        ILogger<Annunciator> logger)
    {
        _dialogueManager = dialogueManager;
        _vengeanceListManager = vengeanceListManager;
        _bot = bot;
        _logger = logger;
    }

    public void Start()
    {
        _timer = new Timer(_ => Notification(), null, 
            TimeSpan.Zero, Constants.TimeBetweenNotifications);
        _logger.LogInformation("Таймер начал работу");
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    private void Notification()
    {
        foreach (var userId in _dialogueManager.GetDialogueIds())
        {
            var vengeanceList = _vengeanceListManager.GetVengeanceListForUser(userId);
            vengeanceList.NotifyUser(_bot, userId);
        }
        _logger.LogInformation("Оповестил всех пользователей");
    }
}