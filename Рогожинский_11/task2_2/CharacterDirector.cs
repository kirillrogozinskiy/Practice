using System.Xml.Linq;

namespace task2_2
{
    public class CharacterDirector
    {
  
        public Character CreateDefaultWarrior(string name)
        {
            var builder = new WarriorBuilder();
            builder.SetName(name);
            builder.SetAge(25);
            builder.SetHealth(200);
            return builder.Build();
        }

        public Character CreateDefaultMage(string name)
        {
            var builder = new MageBuilder();
            builder.SetName(name);
            builder.SetAge(35);
            builder.SetHealth(120);
            return builder.Build();
        }

        public Character CreateDefaultArcher(string name)
        {
            var builder = new ArcherBuilder();
            builder.SetName(name);
            builder.SetAge(28);
            builder.SetHealth(160);
            return builder.Build();
        }

        public Character CreateCustomCharacter(
            ICharacterBuilder builder,
            string name,
            int age,
            int health)
        {
            builder.SetName(name);
            builder.SetAge(age);
            builder.SetHealth(health);
            return builder.Build();
        }
    }
}
