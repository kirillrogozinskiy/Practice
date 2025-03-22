namespace task2
{
    class Coach
    {
        public string Name { get; set; }

        public Coach(string name)
        {
            Name = name;
        }

        public void GiveAdvice()
        {
            Console.WriteLine($"Тренер {Name} дает совет.");
        }
    }
}
