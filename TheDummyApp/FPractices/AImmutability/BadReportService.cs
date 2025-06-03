using TheDummyApp.FPractices.AImmutability.Models;

namespace TheDummyApp.FPractices.AImmutability
{

    public class BadReportService
    {
        public Report CreateQuarterlyReport()
        {
            return new Report { Title = "Q2 Financial Report (Draft)" };
        }

        public void FinalizeReport(Report report)
        {
            report.Title = report.Title.Replace("(Draft)", "(Final)");
        }

        public void GeneratePdf(Report report)
        {
            Console.WriteLine($"Generating PDF: {report.Title}");
            // PDF generation logic...
        }

        public void ProcessReport()
        {
            var report = CreateQuarterlyReport();  // Title: "Q2 Financial Report (Draft)"

            // In one part of the system:
            GeneratePdf(report);  // Outputs: "Generating PDF: Q2 Financial Report (Draft)"

            // Meanwhile in another part:
            FinalizeReport(report);  // Modifies the title

            // Later reuse:
            GeneratePdf(report);  // Now outputs: "Generating PDF: Q2 Financial Report (Final)"

            // Problem: The original report object was mutated unexpectedly
        }
    }



}
