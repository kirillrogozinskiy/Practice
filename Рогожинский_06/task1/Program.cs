namespace task1
{

    public class Program
    {
        public static void Main(string[] args)
        {
            LearningMode[] learningModes = new LearningMode[]
            {
                new OnlineLearning(),
                new OfflineLearning(),
                new HybrideLearning(),
                new OnlineLearning(),
                new OfflineLearning()
            };

            Console.WriteLine("Типы обучения и их особенности:");
            foreach (LearningMode mode in learningModes)
            {
                Console.WriteLine($"Тип: {mode.GetLearningType()}");
                Console.WriteLine($"Описание: {mode.GetDescription()}");
                Console.WriteLine();
            }
        }
    }
}
