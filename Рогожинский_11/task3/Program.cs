using task3;

class Program
{
    static void Main(string[] args)
    {
        var orderSystem = new OrderSystem();

        var chef = new Chef("Иван");
        var waiter = new Waiter("Анна");
        var customer = new Customer("Сергей");

        orderSystem.AddObserver(chef);
        orderSystem.AddObserver(waiter);
        orderSystem.AddObserver(customer);

        orderSystem.CreateOrder("Стейк", 5);
    }
}