namespace task1
{
    class OfflineLearning : LearningMode
    {
        public override string GetLearningType()
        {
            return "Offline";
        }

        public override string GetDescription()
        {
            return "Оффлайн обучение: личное общение с преподавателями и студентами, структурированные занятия, традиционная форма обучения.";
        }
    }
}
