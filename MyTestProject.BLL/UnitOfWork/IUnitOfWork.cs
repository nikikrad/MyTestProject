namespace MyTestProject.BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
    }
}
