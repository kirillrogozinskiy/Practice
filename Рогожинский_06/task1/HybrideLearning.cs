namespace task1
{
    class HybrideLearning : LearningMode
    {
        public override string GetLearningType()
        {
            return "Hybrid";
        }

        public override string GetDescription()
        {
            return "Гибридное обучение: сочетание онлайн и оффлайн форматов, гибкость и преимущества обоих подходов.";
        }
    }
}
