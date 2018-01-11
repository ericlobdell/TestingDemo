namespace TestingDemo.Interfaces
{
    public interface IRepository<T>
    {
        T Get(int id);
    }
}
