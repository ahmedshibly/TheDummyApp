namespace TheDummyApp.ETestability.Yes.Helpers
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string subject, string details);
    }
}
