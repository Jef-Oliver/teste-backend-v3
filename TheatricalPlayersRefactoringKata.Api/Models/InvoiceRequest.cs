using System.Collections.Generic;
using TheatricalPlayersRefactoringKata.Domain.Models;

namespace TheatricalPlayersRefactoringKata.Api.Models;

public class InvoiceRequest
{
    public string Customer { get; set; }
    public List<Performance> Performances { get; set; }
    public List<PlayRequest> Plays { get; set; }
}

public class PlayRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Lines { get; set; }
    public string Type { get; set; }
}
