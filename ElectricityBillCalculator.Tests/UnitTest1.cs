using ElectricityBillCalculator;

namespace ElectricityBillCalculator.Tests;

public class BillCalculatorTests
{
    [Fact]
    public void CalculateBill_ZeroUnits_ReturnsZero()
    {
        BillCalculator calculator = new();

        decimal result = calculator.CalculateBill(0);

        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateBill_TenUnits_ReturnsFifty()
    {
        BillCalculator calculator = new();

        decimal result = calculator.CalculateBill(10);

        Assert.Equal(50, result);
    }

    [Fact]
    public void CalculateBill_SixtyUnits_ReturnsCorrectBill()
    {
        BillCalculator calculator = new();

        decimal result = calculator.CalculateBill(60);

        Assert.Equal(320, result);
    }

    [Fact]
    public void CalculateBill_OneHundredTwentyUnits_ReturnsCorrectBill()
    {
        BillCalculator calculator = new();

        decimal result = calculator.CalculateBill(120);

        Assert.Equal(800, result);
    }

    [Fact]
    public void CalculateBill_NegativeUnits_ThrowsException()
    {
        BillCalculator calculator = new();

        Assert.Throws<ArgumentException>(
            () => calculator.CalculateBill(-10)
        );
    }
}