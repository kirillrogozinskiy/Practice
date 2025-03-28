namespace task2_2
{
    public class MageBuilder : ICharacterBuilder
    {
        private Character Character = new Character();

        public void SetRole()
        {
            Character.Role = "Маг";
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
                Character.Role = "Маг";
            if (Character.Health == 0)
                Character.Health = 150;
            return Character;
        }
    }
}
