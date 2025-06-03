namespace TheDummyApp.ETestability.Yes.Helpers
{
    public interface IEmailService
    {
        Task SendAsync(string customerEmail, string body);
        Task SendWelcomeEmail(string email, string username);
    }
}
