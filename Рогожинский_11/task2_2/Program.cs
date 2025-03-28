namespace task2_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CharacterDirector director = new CharacterDirector();

            Character warrior = director.CreateDefaultWarrior("Александр");
            Character mage = director.CreateDefaultMage("Арес");
            Character archer = director.CreateDefaultArcher("Лекс");

            Character customMage = director.CreateCustomCharacter(
                new MageBuilder(),
                "Саурон",
                150,
                500);

            warrior.DisplayInfo();
            mage.DisplayInfo();
            archer.DisplayInfo();
            customMage.DisplayInfo();
        }
    }
}