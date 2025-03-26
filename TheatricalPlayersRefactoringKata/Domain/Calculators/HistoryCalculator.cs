namespace TheatricalPlayersRefactoringKata.Domain.Calculators;

public class HistoryCalculator : PlayCalculator
{
    private readonly TragedyCalculator _tragedyCalculator = new();
    private readonly ComedyCalculator _comedyCalculator = new();
    
    public override int CalculateAmount(int audience, int lines)
    {
        return _tragedyCalculator.CalculateAmount(audience, lines) + 
               _comedyCalculator.CalculateAmount(audience, lines);
    }
    
    public override int CalculateCredits(int audience)
    {
        return _tragedyCalculator.CalculateCredits(audience) + 
               _comedyCalculator.CalculateCredits(audience);
    }
}