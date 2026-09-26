using Nobatkar.Application.Interfaces;
using Nobatkar.Application.Services;
using Nobatkar.Application.Tests.Fakes;
using Nobatkar.Domain.Entities;
using Nobatkar.Domain.Enums;

namespace Nobatkar.Application.Tests.Services;

public class ShiftCalculatorTests
{
    private readonly ShiftCalculator _calculator = new(new FakeShiftScheduleRepository());

    [Fact]
    public void GetShiftFromDate_ReturnsCorrectShiftFromPattern()
    {
        // Arrange
        var pattern = new ShiftPattern(
            "2 Morning - 2 Night - 4 Rest",
            [
                ShiftType.Morning,
                ShiftType.Morning,
                ShiftType.Night,
                ShiftType.Night,
                ShiftType.Rest,
                ShiftType.Rest,
                ShiftType.Rest,
                ShiftType.Rest
            ]);

        var schedule = new ShiftSchedule(new DateOnly(2026, 9, 1), pattern);

        // Act
        var result1 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 1));
        var result2 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 2));
        var result3 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 3));
        var result4 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 4));
        var result5 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 5));
        var result6 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 8, 31));
        var result7 = _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 9));

        // Assert
        Assert.Equal(ShiftType.Morning, result1);
        Assert.Equal(ShiftType.Morning, result2);
        Assert.Equal(ShiftType.Night, result3);
        Assert.Equal(ShiftType.Night, result4);
        Assert.Equal(ShiftType.Rest, result5);
        Assert.Equal(ShiftType.Rest, result6);
        Assert.Equal(ShiftType.Morning, result7);

    }

    [Fact]
    public void GetShiftForDate_Throws_WhenPatternIsEmpty()
    {
        // Arrange
        var schedule = new ShiftSchedule(new DateOnly(2026, 9, 1), new ShiftPattern());

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        _calculator.GetShiftForDate(schedule, new DateOnly(2026, 9, 1)));
    }

}
