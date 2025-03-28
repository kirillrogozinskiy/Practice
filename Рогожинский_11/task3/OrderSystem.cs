namespace task3
{
    public class OrderSystem
    {
        private List<IOrderObserver> Observers = new List<IOrderObserver>();
        private Order CurrentOrder;

        public void AddObserver(IOrderObserver observer)
        {
            Observers.Add(observer);
        }

        public void RemoveObserver(IOrderObserver observer)
        {
            Observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Update(CurrentOrder);
            }
        }

        public void CreateOrder(string dishName, int tableNumber)
        {
            CurrentOrder = new Order
            {
                DishName = dishName,
                TableNumber = tableNumber,
                Status = "Создан"
            };
            Console.WriteLine($"Новый заказ: {dishName} для стола {tableNumber}");
            NotifyObservers();
        }

        public void UpdateOrderStatus(string newStatus)
        {
            CurrentOrder.Status = newStatus;
            Console.WriteLine($"Статус заказа изменён на: {newStatus}");
            NotifyObservers();
        }
    }
}
