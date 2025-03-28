namespace task2_1
{
    public class JWTAuth : IAuthStrategy
    {
        public bool Authenticate(string jwt)
        {
            Console.WriteLine($"[JWT] Проверка токена: {jwt}");
            return jwt?.StartsWith("Bearer ") == true;
        }
    }
}
