namespace task2_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationService authService = new AuthenticationService(new BasicAuth());
            Console.WriteLine(authService.ExecuteAuthentication("admin:password"));

            authService.SetStrategy(new JWTAuth());
            Console.WriteLine(authService.ExecuteAuthentication("Bearer abc123"));

            authService.SetStrategy(new OAuthAuth());
            Console.WriteLine(authService.ExecuteAuthentication("oauth_token_xyz"));

            authService.SetStrategy(new BasicAuth());
            Console.WriteLine(authService.ExecuteAuthentication("invalid"));
        }
    }
}