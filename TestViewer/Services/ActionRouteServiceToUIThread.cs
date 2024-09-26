using Models;
using System.Windows;
using System.Windows.Threading;
using TestViewer.IServices;

namespace TestViewer.Services;

/// <inheritdoc/>
public class ActionRouteServiceToUIThread : IActionRouteServiceToUIThread
{
    /// <inheritdoc/>
    public void Route(Action action)
    {
        Dispatcher uiDispetcher = Application.Current.Dispatcher;
        uiDispetcher?.InvokeAsync(action);
    }

    /// <inheritdoc/>
    public void Route(Action<DateTimeInternalFormat> action, DateTimeInternalFormat dateTime)
    {
        Dispatcher uiDispetcher = Application.Current.Dispatcher;

        uiDispetcher?.InvokeAsync(() =>
        {
            action(dateTime);
        });
    }
}
