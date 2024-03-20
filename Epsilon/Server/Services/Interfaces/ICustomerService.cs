using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Entities;

namespace Epsilon.Server.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Get(Guid id);

        Task<(IEnumerable<Customer>, int)> GetPagedAsync(Page page);

        Task Insert(CustomerInsertOrUpdate customerInsert);

        Task Update(CustomerInsertOrUpdate customerInsert);

        Task Delete(Guid id);
    }
}
