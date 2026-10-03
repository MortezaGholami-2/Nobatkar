using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nobatkar.App.Services;
using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nobatkar.App.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IShiftCalculator _shiftCalculator;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(ScheduleSummary))]
    [NotifyPropertyChangedFor(nameof(TodayShift))]
    public partial ShiftSchedule? Schedule { get; set; }

    public string ScheduleSummary =>
        Schedule is null
        ? "No shift schedule configured."
        : $"Pattern: {Schedule.Pattern.Name}\n" +
         $"Start date: {Schedule.StartDate:yyyy-MM-dd}";

    public string TodayShift =>
        Schedule is null
        ? "Not configured yet"
        : _shiftCalculator.GetShiftForDate(Schedule, DateOnly.FromDateTime(DateTime.Today)).ToString();

    public DashboardViewModel(INavigationService navigationService, IShiftCalculator shiftCalculator)
    {
        _navigationService = navigationService;
        _shiftCalculator = shiftCalculator;       
    }

    public async Task LoadAsync()
    {
        Schedule = await _shiftCalculator.GetScheduleAsync();
    }

    [RelayCommand]
    private void OpenShiftPlan()
    {
        _navigationService.ShowShiftPlan();
    }

}
