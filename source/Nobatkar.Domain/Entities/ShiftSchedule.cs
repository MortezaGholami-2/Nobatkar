using Nobatkar.Domain.Entities;

namespace Nobatkar.Domain.Entities;

public class ShiftSchedule
{
    public ShiftPattern Pattern { get; private set; }
    public DateOnly StartDate { get; private set; }

    public ShiftSchedule(DateOnly startDate, ShiftPattern pattern)
    {
        ArgumentNullException.ThrowIfNull(pattern);
        
        StartDate = startDate;
        Pattern = pattern;
    }

    public void ChangeStartDate(DateOnly startDate)
    {
        StartDate = startDate;
    }

    public void ChangePattern(ShiftPattern pattern)
    {
        ArgumentNullException.ThrowIfNull(pattern);

        Pattern = pattern;
    }
}
