namespace task5
{
    class Cube : Shape3D
    {
        public double Side { get; set; }

        public Cube(double side)
        {
            Side = side;
        }

        public override double CalculateVolume()
        {
            return Math.Pow(Side, 3);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Это куб со стороной {Side}.");
            Console.WriteLine($"Объем куба: {CalculateVolume()}");
        }
    }
}
