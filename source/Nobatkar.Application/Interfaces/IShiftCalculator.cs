using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;

namespace Nobatkar.Application.Interfaces;

public interface IShiftCalculator
{
    Task<ShiftSchedule?> GetScheduleAsync();

    Task SaveScheduleAsync(ShiftSchedule schedule);

    ShiftType GetShiftForDate(ShiftSchedule schedule, DateOnly date);
}
