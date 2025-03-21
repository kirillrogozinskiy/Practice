namespace task5
{
    abstract class Shape3D
    {
        public abstract double CalculateVolume();
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Это трехмерная фигура.");
        }
    }
}
