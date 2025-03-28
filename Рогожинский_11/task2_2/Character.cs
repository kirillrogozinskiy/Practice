namespace task2_2
{
    public class Character
    {
        public string Name;
        public int Age;
        public string Role;
        public int Health;

        public void DisplayInfo()
        {
            Console.WriteLine($"Имя : {Name}");
            Console.WriteLine($"Возраст : {Age}");
            Console.WriteLine($"Роль : {Role}");
            Console.WriteLine($"Здоровье : {Health}");
        }
    }
}
