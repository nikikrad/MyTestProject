namespace MyTestProject.BLL.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
