namespace TestingDemo.Models
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public User(string firstName, string lastName, int id = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public static User Demo =>
            new User("Demo", "User");
    }
}
