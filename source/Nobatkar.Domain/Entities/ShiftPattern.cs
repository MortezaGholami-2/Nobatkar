using Nobatkar.Domain.Enums;

namespace Nobatkar.Domain.Entities;

public class ShiftPattern
{
    private readonly List<ShiftType> _shifts = [];

    public string Name { get; set; } = string.Empty;

    public IReadOnlyList<ShiftType> Shifts => _shifts;
    
    public ShiftPattern()
    {

    }

    public ShiftPattern(string name, IEnumerable<ShiftType> shifts)
    {
        SetName(name);
        SetShifts(shifts);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));

        Name = name;
    }

    public void SetShifts(IEnumerable<ShiftType> shifts)
    {
        ArgumentNullException.ThrowIfNull(shifts);

        var shiftList = shifts.ToList();
        if (shiftList.Count == 0)
        {
            throw new ArgumentException("A shift pattern must contain at least one shift.", nameof(shifts));
        }

        _shifts.Clear();
        _shifts.AddRange(shiftList);
    }
}
