namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Athlete[] athletes = new Athlete[3];
            athletes[0] = new Athlete("Alice", 2);
            athletes[1] = new Athlete("Bob", 1);
            athletes[2] = new Athlete("Charlie", 3);

            Coach coach1 = new Coach("John");
            Coach coach2 = new Coach("Jane");
            Coach coach3 = new Coach("Mike");

            Team teamA = new Team("Team Alpha");
            Team teamB = new Team("Team Beta");

            athletes[0].AddCoach(coach1, 0);
            athletes[0].AddCoach(coach2, 1);
            athletes[1].AddCoach(coach3, 0);
            athletes[2].AddCoach(coach1, 0);
            athletes[2].AddCoach(coach2, 1);
            athletes[2].AddCoach(coach3, 2);

            athletes[0].SetTeam(teamA);
            athletes[1].SetTeam(teamB);
            athletes[2].SetTeam(teamA);

            athletes[1].Equipment.Item = "Специальные ботинки";

            foreach (var athlete in athletes)
            {
                athlete.Train();
                Console.WriteLine();
            }
        }
    }
}