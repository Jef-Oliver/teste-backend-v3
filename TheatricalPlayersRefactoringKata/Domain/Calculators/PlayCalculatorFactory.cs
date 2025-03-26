namespace TheatricalPlayersRefactoringKata.Domain.Calculators;
using System;

public static class PlayCalculatorFactory
{
    public static PlayCalculator CreateCalculator(string playType)
    {
        return playType switch
        {
            "tragedy" => new TragedyCalculator(),
            "comedy" => new ComedyCalculator(),
            "history" => new HistoryCalculator(),
            _ => throw new Exception($"unknown type: {playType}")
        };
    }
}