namespace task2_2
{
    public interface ICharacterBuilder
    {
        void SetRole();
        void SetName(string name);
        void SetAge(int age);
        void SetHealth(int health);
        Character Build();
    }
}
