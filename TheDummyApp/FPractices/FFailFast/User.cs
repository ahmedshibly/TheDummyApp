namespace TheDummyApp.FPractices.FFailFast
{
    internal class User
    {
        private string username;
        private string email;

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public Guid Id { get; internal set; }

        internal void SetPassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}