namespace TheDummyApp.FPractices.AImmutability.Models
{
    public record RobustReport(string Title, bool IsFinal = false)
    {
        public string DisplayTitle => IsFinal
            ? Title.Replace("(Draft)", "(Final)")
            : Title;
    }
}
