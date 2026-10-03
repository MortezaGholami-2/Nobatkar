using Microsoft.Extensions.DependencyInjection;
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

    public void ShowDashboard()
    {
        var dashboardView = _serviceProvider.GetRequiredService<DashboardView>();
        _navigationHost.Frame!.Content = dashboardView;
    }

    public void ShowShiftPlan()
    {
        var shiftPlanView = _serviceProvider.GetRequiredService<ShiftPlanView>();
        _navigationHost.Frame!.Content = shiftPlanView;
    }

}
