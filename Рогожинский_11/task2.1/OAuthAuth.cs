namespace task2_1
{
    public class OAuthAuth : IAuthStrategy
    {
        public bool Authenticate(string token)
        {
            Console.WriteLine($"[OAuth] Проверка токена: {token}");
            return !string.IsNullOrEmpty(token);
        }
    }
}
