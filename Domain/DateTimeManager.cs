using Contracts;
using IDomain;
using Models;

namespace Domain;

/// <summary>
/// Класс предоставление времени.
/// </summary>
public class DateTimeManager : IDateTimeManager
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="actionRoute"></param>
    /// <param name="timeZone"></param>
    /// <param name="actionRoute">Сервис перенаправления действия в пользовательский поток.</param>
    /// <param name="actionCallback">Дейтсвие, маршрутизируемое в вызывающий поток.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public DateTimeManager(IActionRouteService actionRoute, TimeZoneInfo timeZone, string descriptionTimZone, Action<DateTimeInternalFormat> actionCallback)
    {
        if (timeZone == null)
        {
            throw new ArgumentNullException(nameof(timeZone), "Не определен часовой пояс.");
        }

        if (actionCallback == null)
        {
            throw new ArgumentNullException(nameof(actionCallback), "Не определено действие timerCallback.");
        }

        if (actionRoute == null)
        {
            throw new ArgumentNullException(nameof(actionCallback), "Сервис перенаправления действия в пользовательский поток не опеределён.");
        }

        _timeZone = timeZone;
        _descriptionTimZone = !string.IsNullOrWhiteSpace(descriptionTimZone) ? descriptionTimZone : string.Empty;
        _actionCallback = actionCallback;
        _actionRoute = actionRoute;
    }

    /// <inheritdoc/>
    public async Task RunTimer()
    {
        try
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay((int)_timerPeriod);

                    DateTime expectedTimeZoneDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone);
                    DateTimeInternalFormat dateTimeInternalFormat = new DateTimeInternalFormat(expectedTimeZoneDateTime, _timeZone, _descriptionTimZone);

                    _actionRoute.Route(_actionCallback, dateTimeInternalFormat);
                }
            });
        }
        catch { }
    }

    private readonly TimeZoneInfo _timeZone;            // Часовой пояс.
    private readonly string _descriptionTimZone;        // Текстовое описание часового пояса.
    private readonly uint _timerPeriod = 2000U;         // Период получения даты и времени.
    private readonly Action<DateTimeInternalFormat> _actionCallback;  // Дейтсвие, маршрутизируемое в вызывающий поток.

    private readonly IActionRouteService _actionRoute;
}
