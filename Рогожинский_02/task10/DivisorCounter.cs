﻿namespace task10
{
    class DivisorCounter
    {
        public static int CountDivisors(int n)
        {
            int count = 0;
            for (int i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    if (n / i == i)
                    {
                        count++;
                    }
                    else
                    {
                        count += 2;
                    }
                }
            }
            return count;
        }
    }
}
