using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;

namespace Nobatkar.Infrastructure.Persistence;

public class ShiftScheduleRepository : IShiftScheduleRepository
{
    private ShiftSchedule? _schedule;

    public Task<ShiftSchedule?> GetAsync()
    {
        return Task.FromResult(_schedule);
    }

    public Task SaveAsync(ShiftSchedule schedule)
    {
        ArgumentNullException.ThrowIfNull(schedule);
        _schedule = schedule;
        return Task.CompletedTask;
    }
}
