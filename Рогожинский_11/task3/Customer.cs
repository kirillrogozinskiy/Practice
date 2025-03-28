namespace task3
{
    public class Customer : IOrderObserver
    {
        private string Name;

        public Customer(string name)
        {
            Name = name;
        }

        public void Update(Order order)
        {
            if (order.Status == "Готов")
            {
                Console.WriteLine($"{Name} (клиент): Заказ {order.DishName} готов! Можно забирать со стола {order.TableNumber}");
            }
            else if (order.Status == "Подано")
            {
                Console.WriteLine($"{Name} (клиент): Спасибо за заказ {order.DishName}! Приятного аппетита!");
            }
        }
    }
}
