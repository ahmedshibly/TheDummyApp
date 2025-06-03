using TheDummyApp.FPractices.AImmutability.Models;

namespace TheDummyApp.FPractices.AImmutability
{
    public class BetterReportService
    {
        public ImmutableReport CreateQuarterlyReport()
        {
            return new ImmutableReport("Q2 Financial Report (Draft)");
        }

        public ImmutableReport FinalizeReport(ImmutableReport report)
        {
            return report.WithFinalizedTitle();  // Returns a new instance
        }

        public void GeneratePdf(ImmutableReport report)
        {
            Console.WriteLine($"Generating PDF: {report.Title}");
            // PDF generation logic...
        }

        public void ProcessReport()
        {
            var draftReport = CreateQuarterlyReport();  // Title: "Q2 Financial Report (Draft)"

            // First PDF generation gets the draft version
            GeneratePdf(draftReport);  // Outputs: "Generating PDF: Q2 Financial Report (Draft)"

            // Finalizing creates a new instance
            var finalReport = FinalizeReport(draftReport);

            // Second PDF generation gets the final version
            GeneratePdf(finalReport);  // Outputs: "Generating PDF: Q2 Financial Report (Final)"

            // Original draft remains unchanged
            GeneratePdf(draftReport);  // Still outputs: "Generating PDF: Q2 Financial Report (Draft)"
        }
    }
}
