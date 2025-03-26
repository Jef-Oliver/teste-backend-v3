namespace TheatricalPlayersRefactoringKata.Domain.Interfaces;
using TheatricalPlayersRefactoringKata.Domain.Models;

public interface IStatementFormatter
{
    string Format(StatementData data);
}