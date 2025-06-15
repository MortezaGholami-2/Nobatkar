using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nobatkar_WinUI.Views;
using Nobatkar_WinUI.Interfaces.IServices;

namespace Nobatkar_WinUI.Services;

public class ActivationService : IActivationService
{

    private UIElement? _shell = null;

    public ActivationService(/*ActivationHandler<LaunchActivatedEventArgs> defaultHandler, IEnumerable<IActivationHandler> activationHandlers*//*, IThemeSelectorService themeSelectorService*/)
    {

    }

    private async Task InitializeAsync()
    {
        // checking database
        // filling database
        // checking settings
        //await _themeSelectorService.InitializeAsync().ConfigureAwait(false);
        await Task.CompletedTask;
    }

    public async Task ActivateAsync(object activationArgs)
    {
        // Execute tasks before activation.
        await InitializeAsync();

        // Set the MainWindow Content.
        if (App.MainWindow.Content == null)
        {
            App.MainWindow.Content = _shell ?? new Frame();
        }

        // Handle activation via ActivationHandlers.
        //await HandleActivationAsync(activationArgs);

        // Activate the MainWindow.
        App.MainWindow.Activate();

        // Execute tasks after activation.
        await StartupAsync();
    }

    private async Task StartupAsync()
    {
        //await _themeSelectorService.SetRequestedThemeAsync();
        await Task.CompletedTask;
    }
}
