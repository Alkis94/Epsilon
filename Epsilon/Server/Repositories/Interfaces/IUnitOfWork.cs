namespace Epsilon.Server.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
