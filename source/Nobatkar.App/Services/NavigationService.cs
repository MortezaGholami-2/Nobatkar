using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Nobatkar.App.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nobatkar.App.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly NavigationHost _navigationHost;

    public NavigationService(IServiceProvider serviceProvider, NavigationHost navigationHost)
    {
        _serviceProvider = serviceProvider;
        _navigationHost = navigationHost;
    }

    public void NavigateTo<TView>() where TView : Page
    {
        var view = _serviceProvider.GetRequiredService<TView>();
        _navigationHost.Frame!.Content = view;
    }

}
