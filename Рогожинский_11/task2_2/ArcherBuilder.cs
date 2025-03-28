namespace task2_2
{
    public class ArcherBuilder
    {
        private Character Character = new Character();

        public void SetRole()
        {
            Character.Role = "Лучник";
        }

        public void SetAge(int age)
        {
            Character.Age = age;
        }

        public void SetName(string name)
        {
            Character.Name = name;
        }

        public void SetHealth(int health)
        {
            Character.Health = health;
        }

        public Character Build()
        {
            if (string.IsNullOrEmpty(Character.Role))
                Character.Role = "Лучник";
            if (Character.Health == 0)
                Character.Health = 150;
            return Character;
        }
    }
}
