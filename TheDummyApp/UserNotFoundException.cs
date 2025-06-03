namespace TheDummyApp
{
    public class UserNotFoundException(string error) : Exception(error)
    {

    }
}
