namespace TestingDemo.Models
{
    public class Order
    {
        public int Id { get; }
        public int UserId { get; }

        public Order(int userId)
        {
            UserId = userId;
        }
    }
}
