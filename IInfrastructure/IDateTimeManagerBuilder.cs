using IDomain;
using Models;

namespace IInfrastructure;

/// <summary>
/// Сервис создания менеджера времени и даты.
/// </summary>
public interface IDateTimeManagerBuilder
{
    /// <summary>
    /// Создать менеджер времени и даты.
    /// </summary>
    /// <param name="timeZone">Часовой пояс.</param>
    /// <param name="descriptinTimeZone">Текстовое описание даты и времени.</param>
    /// <param name="actionCallback"></param>
    /// <returns></returns>
    IDateTimeManager Build(TimeZoneInfo timeZone,
                           string descriptinTimeZone,
                           Action<DateTimeInternalFormat> actionCallback);
}

