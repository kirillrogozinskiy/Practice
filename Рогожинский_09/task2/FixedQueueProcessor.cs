namespace task2
{
    public class FixedQueueProcessor<T>
    {
        public MyFixedQueue<T> Queue;

        public FixedQueueProcessor(int maxSize)  
        { 
            Queue = new MyFixedQueue<T>(maxSize); 
        }

        public void Add(T item)
        {
            Queue.Enqueue(item);
            Console.WriteLine($"Добавили: {item} (в очереди: {Queue.Count()}/{Queue.MaxSize})");
        }

        public T ProcessNext()  
        { 
            return Queue.Dequeue(); 
        }
    }
}
