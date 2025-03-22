namespace task2
{
    class Athlete
    {
        public string Name { get; set; }
        public Coach[] Coaches { get; set; }
        public Equipment Equipment { get; set; }
        public Team Team { get; set; }

        public Athlete(string name, int coachCount)
        {
            Name = name;
            Coaches = new Coach[coachCount];
            Equipment = new Equipment();
        }

        public void Train()
        {
            Console.WriteLine($"{Name} тренируется...");
            Equipment.Use();
            foreach (var coach in Coaches.Where(c => c != null))
            {
                Console.WriteLine($"  - Под руководством тренера {coach.Name}");
                coach.GiveAdvice();
            }
        }
        public void SetTeam(Team team)
        {
            Team = team; // Ассоциация: связь с Team
            Console.WriteLine($"{Name} теперь часть команды {Team.Name}.");
        }

        public void AddCoach(Coach coach, int index)
        {
            if (index >= 0 && index < Coaches.Length)
            {
                Coaches[index] = coach;
            }
            else
            {
                Console.WriteLine("Неверный индекс тренера.");
            }
        }
    }
}
