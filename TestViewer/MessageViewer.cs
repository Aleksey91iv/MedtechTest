using IDomain;
using IInfrastructure;
using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using ViewModels;
using ViewModels.IServices;
using ViewModels.Observable;

namespace TestViewer;

/// <summary>
/// Модель представления отображения коллекции.
/// </summary>
public class MessageViewer : NotifyPropertyChangedBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dateTimeManagerBuilder">Сервис создания менеджера времени и даты.</param>
    /// <param name="dateTimeMapper">Сервис маппирования моделей описания даты и времени и их моделей представления.</param>
    public MessageViewer(IDateTimeManagerBuilder dateTimeManagerBuilder,
                         IDateTimeMapper dateTimeMapper)
    {
        _dateTimeMapper = dateTimeMapper;
        _timeZone = TimeZoneInfo.GetSystemTimeZones()[83];
        _dateTimerManager = dateTimeManagerBuilder.Build(_timeZone, timeZoneDescription, Add);

        DateTimeDescriptions = new ObservableCollection<DateTimeDescription>();
        _dateTimeDescriptionsView = CollectionViewSource.GetDefaultView(DateTimeDescriptions);
        _dateTimeDescriptionsView.Filter = FilterDateTimeDescriptions;
    }

    /// <summary>
    /// Шаблон фильтра
    /// </summary>
    public string Filter
    {
        get => _filter;
        set
        {
            _filter = value;
            _dateTimeDescriptionsView.Refresh();
            RaisePropertyChanged();
        }
    }
    private string _filter;

    /// <summary>
    /// Оригинальная коллекция.
    /// </summary>
    public ObservableCollection<DateTimeDescription> DateTimeDescriptions
    {
        get => _dateTimeDescriptions;
        set
        {
            _dateTimeDescriptions = value;
            RaisePropertyChanged();
        }
    }
    private ObservableCollection<DateTimeDescription> _dateTimeDescriptions;

    /// <summary>
    /// Запуск работы сервисных задач
    /// </summary>
    public async void Run()
    {
        await _dateTimerManager.RunTimer();
    }

    /// <summary>
    /// Доабвление в коллекцию элементов
    /// </summary>
    public void Add(DateTimeInternalFormat dateTimeInternalFormat)
    {
        DateTimeDescription viewModel = _dateTimeMapper.ToViewModel(dateTimeInternalFormat);

        if (viewModel == null)
        {
            return;
        }

        if (DateTimeDescriptions.Count >= collectionCapacity)
        {
            DateTimeDescriptions.RemoveAt(0);
        }

        DateTimeDescriptions.Add(viewModel);
    }

    private bool FilterDateTimeDescriptions(object obj)
    {
        DateTimeDescription dateTimeDescription = (DateTimeDescription)obj;

        return string.IsNullOrEmpty(Filter)
                     ? true
                     : string.Concat(dateTimeDescription.DateTime, dateTimeDescription.Text).Contains(Filter);
    }

    private ICollectionView _dateTimeDescriptionsView;

    private const string timeZoneDescription = "Самарское время";
    private readonly TimeZoneInfo _timeZone;

    private readonly IDateTimeManager _dateTimerManager;

    private readonly IDateTimeMapper _dateTimeMapper;

    private const int collectionCapacity = 5000; // Ограничение размера коллекции
}
