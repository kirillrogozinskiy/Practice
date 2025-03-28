namespace task2_1
{
    public class AuthenticationService
    {
        private IAuthStrategy AuthStrategy;

        public AuthenticationService(IAuthStrategy strategy) 
        { 
            SetStrategy(strategy); 
        }

        public void SetStrategy(IAuthStrategy strategy) 
        {
            AuthStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public bool ExecuteAuthentication(string input) 
        {
            return AuthStrategy.Authenticate(input);
        }
    }
}
