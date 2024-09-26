using Models;
using ViewModels.IServices;

namespace ViewModels.Services;

public class DateTimeMapper : IDateTimeMapper
{
    public DateTimeDescription ToViewModel(DateTimeInternalFormat dateTime)
    {
        byte day = (byte)dateTime.DateTime.Day;
        byte month = (byte)dateTime.DateTime.Month;
        byte year = (byte)dateTime.DateTime.Day;
        byte hour = (byte)dateTime.DateTime.Hour;
        byte minute = (byte)dateTime.DateTime.Minute;
        byte second = (byte)dateTime.DateTime.Second;

        string dateTimeText = string.Concat(day < 10 ? $"0{day}" : day, ".",
                                            month < 10 ? $"0{month}" : month, ".",
                                            year, " ",
                                            hour < 10 ? $"0{hour}" : hour, ":",
                                            minute < 10 ? $"0{minute}" : minute, ":",
                                            second < 10 ? $"0{second}" : second);

        string text = string.Concat(dateTime.TimeZoneDescription, " ",
                                    hour < 10 ? $"0{hour}" : hour, ":",
                                    minute < 10 ? $"0{minute}" : minute, ":",
                                    second < 10 ? $"0{second}" : second);

        return new DateTimeDescription(dateTimeText, text);
    }
}
