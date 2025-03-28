namespace task3
{
    public class Waiter : IOrderObserver
    {
        private string Name;

        public Waiter(string name)
        {
            Name = name;
        }

        public void Update(Order order)
        {
            if (order.Status == "Создан")
            {
                Console.WriteLine($"{Name} (официант): Принял новый заказ {order.DishName} для стола {order.TableNumber}");
            }
            else if (order.Status == "Готов")
            {
                Console.WriteLine($"{Name} (официант): Забираю заказ {order.DishName} для стола {order.TableNumber}");
                System.Threading.Thread.Sleep(1000);
                order.Status = "Подано";
            }
        }
    }
}
