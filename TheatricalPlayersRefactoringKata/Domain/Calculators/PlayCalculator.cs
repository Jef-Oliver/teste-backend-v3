namespace TheatricalPlayersRefactoringKata.Domain.Calculators;
using System;

public abstract class PlayCalculator
{
    public abstract int CalculateAmount(int audience, int lines);
    public abstract int CalculateCredits(int audience);
    
    protected int CalculateBaseAmount(int lines)
    {
        var clampedLines = Math.Clamp(lines, 1000, 4000);
        return clampedLines / 10;
    }
}