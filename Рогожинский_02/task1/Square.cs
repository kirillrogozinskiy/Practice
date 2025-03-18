namespace task1
{
    class Square
    {
        double Side;

        public Square(double side)
        {
            Side = side;
        }

        public double GetPerimetr()
        {
            return Side * 4;
        }
    }
}
