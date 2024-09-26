namespace Models;

/// <summary>
/// Собственный формат описания врмени.
/// </summary>
public class DateTimeInternalFormat
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dateTime">Дата и время в задщанном часовом поясе.</param>
    /// <param name="timeZoneInfo">Часовой пояс.</param>
    /// <param name="timeZoneDescription">Тектовое описание часового пояса.</param>
    public DateTimeInternalFormat(DateTime dateTime, TimeZoneInfo timeZoneInfo, string timeZoneDescription)
    {
        DateTime = dateTime;
        TimeZoneInfo = timeZoneInfo;
        TimeZoneDescription = string.IsNullOrWhiteSpace(timeZoneDescription)
                                    ? TimeZoneInfo.DisplayName
                                    : timeZoneDescription;
    }

    /// <summary>
    /// Дата и время.
    /// </summary>
    public DateTime DateTime { get; }

    /// <summary>
    /// Часовой пояс.
    /// </summary>
    public TimeZoneInfo TimeZoneInfo { get; }

    /// <summary>
    /// Тектовое описание часового пояса.
    /// </summary>
    public string TimeZoneDescription { get; }
}
