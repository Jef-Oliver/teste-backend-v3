// Domain/Models/StatementData.cs
using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Domain.Models;

public class StatementData
{
    public string Customer { get; }
    public List<Performance> Performances { get; } = new();
    public int TotalAmount { get; private set; }
    public int TotalCredits { get; private set; }
    
    public StatementData(string customer)
    {
        Customer = customer;
    }
    
    public void AddPerformance(Performance performance)
    {
        Performances.Add(performance);
    }
    
    public void AddToTotalAmount(int amount)
    {
        TotalAmount += amount;
    }
    
    public void AddCredits(int credits)
    {
        TotalCredits += credits;
    }
}