namespace TheDummyApp.FPractices.FFailFast
{
    internal interface IUserRepository
    {
        Task Add(User user);
        Task<bool> ExistsByEmail(string email);
        Task<bool> ExistsByUsername(string username);
        Task SaveChanges();
    }
}