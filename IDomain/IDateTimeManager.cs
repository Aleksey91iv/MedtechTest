namespace IDomain
{
    /// <summary>
    /// Интерфейс менеджера даты и времени
    /// </summary>
    public interface IDateTimeManager
    {
        /// <summary>
        /// Запуск таймера.
        /// </summary>
        /// <returns></returns>
        Task RunTimer();
    }
}
