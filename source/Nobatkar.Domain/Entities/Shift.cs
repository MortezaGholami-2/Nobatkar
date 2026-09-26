using Nobatkar.Domain.Enums;

namespace Nobatkar.Domain.Entities;

public class Shift
{
    public DateOnly Date { get; set; }
    public ShiftType Type { get; set; }
}
