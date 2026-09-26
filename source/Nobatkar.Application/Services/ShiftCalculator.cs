using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;

namespace Nobatkar.Application.Services;

public class ShiftCalculator
{
    private readonly IShiftScheduleRepository _repository;

    public ShiftCalculator(IShiftScheduleRepository repository)
    {
        _repository = repository;
    }

    public ShiftType GetShiftForDate(ShiftSchedule schedule, DateOnly date)
    {
        if (schedule.Pattern.Shifts.Count == 0)
        {
            throw new InvalidOperationException("The shift pattern cannot be empty.");
        }

        int daysFromStart = date.DayNumber - schedule.StartDate.DayNumber;

        int patternIndex = ((daysFromStart % schedule.Pattern.Shifts.Count)
            + schedule.Pattern.Shifts.Count)
            % schedule.Pattern.Shifts.Count;

        return schedule.Pattern.Shifts[patternIndex];
    }
}
