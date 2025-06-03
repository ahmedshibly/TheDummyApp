namespace TheDummyApp.FPractices.FFailFast
{
    internal interface IEmailService
    {
        Task SendWelcomeEmail(string email, string username);
    }
}