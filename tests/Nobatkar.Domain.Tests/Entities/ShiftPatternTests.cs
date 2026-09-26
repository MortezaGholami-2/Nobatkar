using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;

namespace Nobatkar.Domain.Tests.Entities;

public class ShiftPatternTests
{
    [Fact]
    public void Constructor_Throws_WhenPatternIsEmpty()
    {
        // Arrange
        var shifts = Array.Empty<ShiftType>();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => 
            new ShiftPattern("Empty Pattern", shifts));
    }

    [Fact]
    public void Constructor_CreateValidPattern()
    {
        // Arrange
        var shifts = new List<ShiftType>
        {
            ShiftType.Morning,
            ShiftType.Night,
            ShiftType.Rest
        };

        // Act
        var pattern = new ShiftPattern("Valid Pattern", shifts);

        // Assert
        Assert.Equal("Valid Pattern", pattern.Name);
        Assert.Equal(3, pattern.Shifts.Count);
    }
}
