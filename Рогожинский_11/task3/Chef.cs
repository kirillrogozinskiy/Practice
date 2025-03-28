namespace task3
{
    public class Chef : IOrderObserver
    {
        private string Name;

        public Chef(string name)
        {
            Name = name;
        }

        public void Update(Order order)
        {
            if (order.Status == "Создан")
            {
                Console.WriteLine($"{Name} (повар): Принял заказ {order.DishName} для стола {order.TableNumber}. Готовлю...");
                System.Threading.Thread.Sleep(2000);
                order.Status = "Готов";
            }
        }
    }
}
