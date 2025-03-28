namespace task2_1
{
    public interface IAuthStrategy
    {
        bool Authenticate(string credentials);
    }

}
