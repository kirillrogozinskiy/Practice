namespace task4
{
    static class StringExtention
    {
        public static bool IsDigitsOnly(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
