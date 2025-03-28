namespace task2_1
{
    public class BasicAuth : IAuthStrategy
    {
        public bool Authenticate(string credentials)
        {
            Console.WriteLine($"[Basic] Проверка логина/пароля: {credentials}");
            return credentials?.Contains(":") == true;
        }
    }
}
