using MyTestProject.BLL.UnitOfWork;

namespace MyTestProject.DAL.UnitOfWork
{
    public class UnitOfWork2 : IUnitOfWork
    {
        private readonly StoreContext _storeContext;

        public UnitOfWork2(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public Task<int> SaveChanges()
        {
            Console.WriteLine("Привет");
            return _storeContext.SaveChangesAsync();
        }
    }
}
