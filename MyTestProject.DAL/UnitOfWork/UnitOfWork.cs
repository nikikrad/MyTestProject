using MyTestProject.BLL.UnitOfWork;

namespace MyTestProject.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Task<int> SaveChanges()
        {
            return _storeContext.SaveChangesAsync();
        }
    }
}
