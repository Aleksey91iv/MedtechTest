using ViewModels.Observable;

namespace ViewModels;

/// <summary>
/// Модель представления опсиания даты и времени.
/// </summary>
public class DateTimeDescription : NotifyPropertyChangedBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dateTime">Время в собственном формате.</param>
    /// <param name="message">Текст сообщения.</param>
    public DateTimeDescription(string dateTime, string text)
    {
        if (dateTime == null)
        {
            throw new ArgumentNullException(nameof(dateTime), "Отсутствует дата и время.");
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentNullException(nameof(text), "Отсутствует текст сообщения.");
        }

        DateTime = dateTime;
        Text = text;
    }

    /// <summary>
    /// Дата и время в текстовом формате.
    /// </summary>
    public string DateTime
    {
        get => _dateTime;
        private set
        {
            _dateTime = value;
            RaisePropertyChanged();
        }
    }
    private string _dateTime;

    /// <summary>
    /// Текст сообщения.
    /// </summary>
    public string Text
    {
        get => _text;
        private set
        {
            _text = value;
            RaisePropertyChanged();
        }
    }
    private string _text;
}
