using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheDummyApp.FPractices.AImmutability.Models;

namespace TheDummyApp.FPractices.AImmutability
{
    public class RobustReportService
    {
        public RobustReport CreateQuarterlyReport() =>
            new("Q2 Financial Report (Draft)");

        public RobustReport FinalizeReport(RobustReport report) =>
            report with { IsFinal = true };

        public void GeneratePdf(RobustReport report) =>
            Console.WriteLine($"Generating PDF: {report.DisplayTitle}");

        public void ProcessReport()
        {
            var draft = CreateQuarterlyReport();
            GeneratePdf(draft);  // "Generating PDF: Q2 Financial Report (Draft)"

            var final = FinalizeReport(draft);
            GeneratePdf(final);  // "Generating PDF: Q2 Financial Report (Final)"

            // Original remains unchanged
            GeneratePdf(draft);  // Still shows "(Draft)"
        }
    }
}
