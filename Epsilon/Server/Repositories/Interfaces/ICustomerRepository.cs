using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Entities;

namespace Epsilon.Server.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<(IEnumerable<Customer>, int)> GetPagedAsync(Page page);
    }
}
