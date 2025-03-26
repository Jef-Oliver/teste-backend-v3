using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain.Calculators;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;
using TheatricalPlayersRefactoringKata.Domain.Models;
using TheatricalPlayersRefactoringKata.Formatters;

namespace TheatricalPlayersRefactoringKata.Application;

public class StatementPrinter
{
    private readonly IStatementFormatter _formatter;

    // Injeção de dependência do formatador
    public StatementPrinter(IStatementFormatter formatter)
    {
        _formatter = formatter;
    }

    // Método principal/pode ser usado para qualquer formato
    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var statementData = new StatementData(invoice.Customer);
        
        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var calculator = PlayCalculatorFactory.CreateCalculator(play.Type);
            
            var amount = calculator.CalculateAmount(perf.Audience, play.Lines);
            var credits = calculator.CalculateCredits(perf.Audience);
            
            // Atualiza a performance existente
            perf.Name = play.Name;
            perf.Amount = amount;
            
            statementData.AddPerformance(perf); // Agora aceita Performance
            statementData.AddCredits(credits);
            statementData.AddToTotalAmount(amount);
        }
        
        return _formatter.Format(statementData);
    }

    // Métodos de conveniência para os formatos específicos
    public static string PrintAsText(Invoice invoice, Dictionary<string, Play> plays)
    {
        var textFormatter = new TextStatementFormatter();
        var printer = new StatementPrinter(textFormatter);
        return printer.Print(invoice, plays);
    }

    public static string PrintAsXml(Invoice invoice, Dictionary<string, Play> plays)
    {
        var xmlFormatter = new XmlStatementFormatter();
        var printer = new StatementPrinter(xmlFormatter);
        return printer.Print(invoice, plays);
    }
}