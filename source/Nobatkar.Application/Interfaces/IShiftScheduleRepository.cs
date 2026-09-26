using Nobatkar.Domain.Entities;

namespace Nobatkar.Application.Interfaces;

public interface IShiftScheduleRepository
{
    Task<ShiftSchedule?> GetAsync();
    Task SaveAsync(ShiftSchedule schedule);
}
