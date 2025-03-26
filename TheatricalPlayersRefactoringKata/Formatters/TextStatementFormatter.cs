using System.Globalization;
using System.Text;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;
using TheatricalPlayersRefactoringKata.Domain.Models;

namespace TheatricalPlayersRefactoringKata.Formatters;

public class TextStatementFormatter : IStatementFormatter
{
    public string Format(StatementData data)
    {
        var cultureInfo = CultureInfo.GetCultureInfo("en-US");
        var result = new StringBuilder();
        result.AppendLine($"Statement for {data.Customer}");
        
        foreach (var perf in data.Performances)
        {
            result.AppendLine($"  {perf.Name}: {FormatAsUSD(perf.Amount)} ({perf.Audience} seats)");
        }
        
        result.AppendLine($"Amount owed is {FormatAsUSD(data.TotalAmount)}");
        result.Append($"You earned {data.TotalCredits} credits");
        return result.ToString();
    }
    
    private static string FormatAsUSD(int amount)
    {
        return (amount / 100).ToString("C", CultureInfo.GetCultureInfo("en-US"));
    }
}