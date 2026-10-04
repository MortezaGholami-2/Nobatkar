using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Nobatkar.App.Services;
using Nobatkar.App.Views;
using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Nobatkar.App.ViewModels;

public partial class ShiftPlanViewModel : ObservableObject
{

    private readonly INavigationService _navigationService;
    private readonly IShiftCalculator _shiftCalculator;

    [ObservableProperty]
    public partial string PlanName {  get; set; } = string.Empty;

    [ObservableProperty]
    public partial DateTime StartDate { get; set; } = DateTime.Today;

    [ObservableProperty]
    public partial ShiftType SelectedShift { get; set; } = ShiftType.Morning;

    public ObservableCollection<ShiftType> Shifts { get; } = [];

    public IReadOnlyList<ShiftType> ShiftTypes { get; } = Enum.GetValues<ShiftType>();

    public ShiftPlanViewModel(INavigationService navigationService, IShiftCalculator shiftCalculator)
    {
        _navigationService = navigationService;
        _shiftCalculator = shiftCalculator;
    }

    [RelayCommand]
    private void AddShift()
    {
        Shifts.Add(SelectedShift);
    }

    [RelayCommand]
    private void RemoveLastShift()
    {
        if (Shifts.Count > 0)
        {
            Shifts.RemoveAt(Shifts.Count - 1);
        }
    }

    [RelayCommand]
    private async Task SaveShiftPlanAsync()
    {
        if (string.IsNullOrWhiteSpace(PlanName))
        {
            return;
        }

        if (Shifts.Count == 0)
        {
            return;
        }

        var pattern = new ShiftPattern(PlanName.Trim(), Shifts);

        var schedule = new ShiftSchedule(DateOnly.FromDateTime(StartDate), pattern);

        await _shiftCalculator.SaveScheduleAsync(schedule);

        _navigationService.NavigateTo<DashboardView>();
    }

}
