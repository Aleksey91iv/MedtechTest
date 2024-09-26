using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels.Observable
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Инициировать событие изменения свойства.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
