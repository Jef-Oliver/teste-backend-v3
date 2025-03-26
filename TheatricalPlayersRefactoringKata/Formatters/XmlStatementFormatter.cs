using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TheatricalPlayersRefactoringKata.Domain.Interfaces;
using TheatricalPlayersRefactoringKata.Domain.Models;

namespace TheatricalPlayersRefactoringKata.Formatters;

public class XmlStatementFormatter : IStatementFormatter
{
    public string Format(StatementData data)
    {
        var xml = new XDocument(
            new XElement("statement",
                new XAttribute("customer", data.Customer),
                new XElement("performances",
                    data.Performances.Select(perf => 
                        new XElement("performance",
                            new XElement("play", perf.Name),
                            new XElement("amount", perf.Amount),
                            new XElement("audience", perf.Audience)
                        )
                    )
                ),
                new XElement("totalAmount", data.TotalAmount),
                new XElement("totalCredits", data.TotalCredits)
            )
        );
        
        var builder = new StringBuilder();
        using var writer = new StringWriter(builder);
        xml.Save(writer, SaveOptions.None);
        return builder.ToString();
    }
}