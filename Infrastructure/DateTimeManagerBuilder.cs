using Contracts;
using IDomain;
using IInfrastructure;
using Models;

namespace Domain.Services;

/// <inheritdoc/>
public class DateTimeManagerBuilder : IDateTimeManagerBuilder
{
    public DateTimeManagerBuilder(IActionRouteService actionRouteService)
    {
        _actionRouteService = actionRouteService;
    }

    /// <inheritdoc/>
    public IDateTimeManager Build (TimeZoneInfo timeZone,
                                  string descriptinTimeZone,
                                  Action<DateTimeInternalFormat> timerCallback)
    {
        try
        {
            DateTimeManager dateTimerManager =
                new DateTimeManager(_actionRouteService, timeZone, descriptinTimeZone, timerCallback);

            return dateTimerManager;
        }
        catch
        {
            return null;
        }
    }

    private readonly IActionRouteService _actionRouteService;
}
