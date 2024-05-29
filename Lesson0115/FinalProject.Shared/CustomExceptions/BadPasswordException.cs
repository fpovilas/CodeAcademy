namespace FinalProject.Shared.CustomExceptions
{
    public class BadPasswordException(string message) : Exception(message) { }
}
