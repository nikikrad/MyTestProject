using MyTestProject.BLL.Repositories;

namespace MyTestProject.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly StoreContext _storeContext;

        public Repository(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }

        public void Create(T item)
        {
            _storeContext.Add<T>(item);
        }

        public void Delete(T item)
        {
            _storeContext.Remove<T>(item);
        }

        public void Update(T item)
        {
            _storeContext.Update<T>(item);
        }
    }
}
