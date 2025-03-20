namespace task1
{
    public class A
    {
        public int a;
        public int b;
        public A(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public double SquareOfDifference()
        {
            return Math.Pow(a, 2) - 2 * a * b + Math.Pow(b, 2); 
        }
        public double CalculatindExpression()
        {
            return 1.0 / (1 + (a + b) / 2.0);
        }
    }
}
