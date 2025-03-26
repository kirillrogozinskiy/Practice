namespace task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FixedQueueProcessor<string> processor = new FixedQueueProcessor<string>(2);

            processor.Add("Первый");   
            processor.Add("Второй");   
            processor.Add("Третий");   

            string item1 = processor.ProcessNext(); 
            string item2 = processor.ProcessNext(); 
        }
    }
}