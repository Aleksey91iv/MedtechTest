using Models;

namespace ViewModels.IServices;

/// <summary>
/// Сервис маппирования моделей описания даты и времени и их моделей представления.
/// </summary>
public interface IDateTimeMapper
{
    /// <summary>
    /// Маппирование модели представления на модель.
    /// </summary>
    /// <param name="dateTime">Дата и время.</param>
    /// <returns>Модель представления.</returns>
    public ViewModels.DateTimeDescription ToViewModel(DateTimeInternalFormat dateTime);
}
