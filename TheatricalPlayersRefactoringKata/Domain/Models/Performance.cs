namespace TheatricalPlayersRefactoringKata.Domain.Models;

public class Performance
{
    public string PlayId { get; }
    public int Audience { get; }
    public string Name { get; set; }
    public int Amount { get; set; }

    public Performance(string playId, int audience)
    {
        PlayId = playId;
        Audience = audience;
    }
}