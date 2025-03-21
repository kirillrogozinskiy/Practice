namespace task5
{
    class Sphere : Shape3D
    {
        public double Radius { get; set; }

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public override double CalculateVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Это сфера с радиусом {Radius}.");
            Console.WriteLine($"Объем сферы: {CalculateVolume():F2}");
        }
    }
}
