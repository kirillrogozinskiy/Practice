namespace task1
{
    public class ElevatorSystem
    {
        private Queue<ElevatorRequest> RequestsQueue;
        private int CurrentFloor;
        private Direction CurrentDirection;

        public ElevatorSystem()
        {
            RequestsQueue = new Queue<ElevatorRequest>();
            CurrentFloor = 1;
            CurrentDirection = Direction.None;
        }

        public void AddRequest(int floorNumber, Direction direction)
        {
            if (floorNumber < 1)
            {
                throw new ArgumentException("Этаж не может быть меньше 1");
            }

            ElevatorRequest request = new ElevatorRequest(floorNumber, direction);
            RequestsQueue.Enqueue(request);
            Console.WriteLine($"Добавлен новый запрос: {request}");
        }

        public void CheckRequest()
        {
            List<ElevatorRequest> itemsToRemove = new List<ElevatorRequest>();

            foreach (var request in RequestsQueue)
            {
                if (CurrentFloor == request.Floor &&
                   (CurrentDirection == request.Direction || request.Direction == Direction.None))
                {
                    Console.WriteLine($"Лифт остановился на {request.Floor} этаже.");
                    itemsToRemove.Add(request);
                }
            }

            foreach (var item in itemsToRemove)
            {
                RemoveRequest(item.Floor, item.Direction);
            }
        }

        public void RemoveRequest(int floorNumber, Direction direction)
        {
            var tempQueue = new Queue<ElevatorRequest>();

            while (RequestsQueue.Count > 0)
            {
                var request = RequestsQueue.Dequeue();
                if (request.Floor != floorNumber || request.Direction != direction)
                {
                    tempQueue.Enqueue(request);
                }
            }

            while (tempQueue.Count > 0)
            {
                RequestsQueue.Enqueue(tempQueue.Dequeue());
            }
        }

        public void MoveUp(int targetFloor)
        {
            Console.WriteLine($"Лифт едет вверх с {CurrentFloor} этажа.");

            while (CurrentFloor < targetFloor)
            {
                CurrentFloor++;
                Console.WriteLine($"Лифт проехал {CurrentFloor} этаж.");
                CheckRequest();
            }
        }

        public void MoveDown(int targetFloor)
        {
            Console.WriteLine($"Лифт едет вниз с {CurrentFloor} этажа.");

            while (CurrentFloor > targetFloor)
            {
                CurrentFloor--;
                Console.WriteLine($"Лифт проехал {CurrentFloor} этаж.");
                CheckRequest();
            }
        }

        public void ProcessRequests()
        {
            Console.WriteLine($"\nНачало обработки запросов. Текущий этаж: {CurrentFloor}");

            while (RequestsQueue.Count > 0)
            {
                var request = RequestsQueue.Dequeue();
                ProcessSingleRequest(request);
            }

            CurrentDirection = Direction.None;
            Console.WriteLine("Все запросы обработаны.");
        }

        private void ProcessSingleRequest(ElevatorRequest request)
        {
            Console.WriteLine($"\nОбработка запроса: {request}");

            if (request.Floor > CurrentFloor)
            {
                CurrentDirection = Direction.Up;
                MoveUp(request.Floor);
            }
            else if (request.Floor < CurrentFloor)
            {
                CurrentDirection = Direction.Down;
                MoveDown(request.Floor);
            }

            Console.WriteLine($"Лифт прибыл на этаж {CurrentFloor}");

            if (request.Direction != Direction.None && CurrentDirection != request.Direction)
            {
                Console.WriteLine($"Пассажир ожидает движение в направлении {request.Direction}");
            }
        }

        public void PrintStatus()
        {
            Console.WriteLine($"\nТекущий этаж: {CurrentFloor}");
            Console.WriteLine($"Текущее направление: {CurrentDirection}");
            Console.WriteLine($"Оставшиеся запросы: {RequestsQueue.Count}");
        }
    }
}
