using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;

namespace Nobatkar.Application.Services;

public class ShiftCalculator : IShiftCalculator
{
    private readonly IShiftScheduleRepository _repository;

    public ShiftCalculator(IShiftScheduleRepository repository)
    {
        _repository = repository;
    }

    public Task<ShiftSchedule?> GetScheduleAsync()
    {
        return _repository.GetAsync();
    }

    public Task SaveScheduleAsync(ShiftSchedule schedule)
    {
        ArgumentNullException.ThrowIfNull(schedule);
        
        return _repository.SaveAsync(schedule);
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
