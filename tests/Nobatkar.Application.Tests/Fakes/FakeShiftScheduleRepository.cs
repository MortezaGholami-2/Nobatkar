using Nobatkar.Application.Interfaces;
using Nobatkar.Domain.Entities;

namespace Nobatkar.Application.Tests.Fakes;

public class FakeShiftScheduleRepository : IShiftScheduleRepository
{
    private ShiftSchedule? _schedule;
    
    public Task<ShiftSchedule?> GetAsync()
    {
        return Task.FromResult(_schedule);
    }

    public Task SaveAsync(ShiftSchedule schedule)
    {
        _schedule = schedule;
        return Task.CompletedTask;
    }
}
