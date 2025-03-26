using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Application;
using TheatricalPlayersRefactoringKata.Api.Models;
using TheatricalPlayersRefactoringKata.Domain.Models;

namespace TheatricalPlayersRefactoringKata.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatementController : ControllerBase
{
    [HttpPost("text")]
    public IActionResult GenerateTextStatement([FromBody] InvoiceRequest request)
    {
        var plays = MapPlays(request.Plays);
        var invoice = new Invoice(request.Customer, request.Performances);
        var result = StatementPrinter.PrintAsText(invoice, plays);
        return Ok(result);
    }

    [HttpPost("xml")]
    public IActionResult GenerateXmlStatement([FromBody] InvoiceRequest request)
    {
        var plays = MapPlays(request.Plays);
        var invoice = new Invoice(request.Customer, request.Performances);
        var result = StatementPrinter.PrintAsXml(invoice, plays);
        return Ok(result);
    }

    private Dictionary<string, Play> MapPlays(List<PlayRequest> plays)
    {
        var dict = new Dictionary<string, Play>();
        foreach (var play in plays)
        {
            dict[play.Id] = new Play(play.Name, play.Lines, play.Type);
        }
        return dict;
    }
}
