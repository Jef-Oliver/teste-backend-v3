namespace TheatricalPlayersRefactoringKata.Domain.Calculators;
using System;

public class ComedyCalculator : PlayCalculator
{
    public override int CalculateAmount(int audience, int lines)
    {
        var baseAmount = CalculateBaseAmount(lines);
        baseAmount += 300 * audience;
        if (audience > 20)
        {
            baseAmount += 10000 + 500 * (audience - 20);
        }
        return baseAmount;
    }
    
    public override int CalculateCredits(int audience)
    {
        return Math.Max(audience - 30, 0) + (int)Math.Floor((decimal)audience / 5);
    }
}