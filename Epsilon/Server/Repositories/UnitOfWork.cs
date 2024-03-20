using Epsilon.Server.Repositories.Interfaces;

namespace Epsilon.Server.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EpsilonDbContext _dbContext;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(EpsilonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository CustomerRepository
        {
            get => _customerRepository ??= new CustomerRepository(
                _dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
