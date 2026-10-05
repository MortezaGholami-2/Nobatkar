using CommunityToolkit.Mvvm.ComponentModel;
using Nobatkar.App.Services;
using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Nobatkar.App.ViewModels;

public partial class CalendarViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly IShiftCalculator _shiftCalculator;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DisplayedMonthText))]
    public partial DateTime DisplayedMonth { get; set; } = DateTime.Today;

    public string DisplayedMonthText =>
    DisplayedMonth.ToString("MMMM yyyy");

    public ObservableCollection<CalendarDayViewModel> Days { get; } = [];

    public CalendarViewModel(INavigationService navigationService, IShiftCalculator shiftCalculator)
    {
        _navigationService = navigationService;
        _shiftCalculator = shiftCalculator;
    }

    public async Task LoadAsync()
    {
        Days.Clear();

        var schedule = await _shiftCalculator.GetScheduleAsync();

        if (schedule is null)
        {
            return;
        }

        var year = DisplayedMonth.Year;
        var month = DisplayedMonth.Month;

        var daysInMonth = DateTime.DaysInMonth(year, month);

        for (int day = 1; day <= daysInMonth; day++)
        {
            var date = new DateOnly(year, month, day);

            var shift = _shiftCalculator.GetShiftForDate(schedule, date);

            Days.Add(new CalendarDayViewModel(date, shift));
        }
    }
}

public class CalendarDayViewModel
{
    public DateOnly Date { get; }

    public int DayNumber => Date.Day;

    public ShiftType Shift { get; }

    public CalendarDayViewModel(DateOnly date, ShiftType shift)
    {
        Date = date;
        Shift = shift;
    }
}
