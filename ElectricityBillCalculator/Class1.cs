namespace ElectricityBillCalculator;

public class BillCalculator
{
public decimal CalculateBill(int units)
    {
        if (units < 0)
        {
            throw new ArgumentException(
                "Electricity usage cannot be negative."
            );
        }

        decimal bill = 0;

        if (units <= 50)
        {
            bill = units * 5;
        }
        else if (units <= 100)
        {
            bill = (50 * 5) + ((units - 50) * 7);
        }
        else
        {
            bill = (50 * 5)
                 + (50 * 7)
                 + ((units - 100) * 10);
        }

        return bill;
    }
}
