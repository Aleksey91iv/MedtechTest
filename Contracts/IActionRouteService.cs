using Models;

namespace Contracts
{
    /// <summary>
    /// Сервис перенаправления action в нужный поток.
    /// </summary>
    public interface IActionRouteService
    {
        /// <summary>
        /// Перенаправить действие в пользовательский поток.
        /// </summary>
        /// <param name="action">Действие.</param>
        public void Route(Action action);

        /// <summary>
        /// Перенаправить действие в пользовательский поток.
        /// </summary>
        /// <param name="action">Действие, перенаправляемое в пользовательский поток.</param>
        /// <param name="dateTimeDescription">Описание времени и даты.</param>
        void Route(Action<DateTimeInternalFormat> action, DateTimeInternalFormat dateTime);
    }
}
