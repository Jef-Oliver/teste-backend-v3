namespace TheatricalPlayersRefactoringKata.Domain.Calculators;
using System;

public class TragedyCalculator : PlayCalculator
{
    public override int CalculateAmount(int audience, int lines)
    {
        var baseAmount = CalculateBaseAmount(lines);
        if (audience > 30)
        {
            baseAmount += 1000 * (audience - 30);
        }
        return baseAmount;
    }
    
    public override int CalculateCredits(int audience)
    {
        return Math.Max(audience - 30, 0);
    }
}