using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain.Models;

namespace TheatricalPlayersRefactoringKata.Domain.Models;

public class Invoice
{
    public string Customer { get; }
    public List<Performance> Performances { get; }

    public Invoice(string customer, List<Performance> performances)
    {
        Customer = customer;
        Performances = performances;
    }
}