namespace task2
{
    public class MyFixedQueue<T>
    {
        public Queue<T> Queue;
        public int MaxSize { get; }

        public MyFixedQueue(int maxSize)
        {
            if (maxSize <= 0) throw new ArgumentException("Размер очереди должен быть > 0");
            MaxSize = maxSize;
            Queue = new Queue<T>(maxSize);
        }

        public void Enqueue(T item)
        {
            if (Queue.Count >= MaxSize) 
            { 
                Queue.Dequeue(); 
            }
            Queue.Enqueue(item);
        }

        public T Dequeue()
        {
            return Queue.Dequeue();
        }

        public int Count()
        {
            return Queue.Count;
        }
    }
}
