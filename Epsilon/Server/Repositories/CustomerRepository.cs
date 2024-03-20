using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Entities;
using Epsilon.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Epsilon.Server.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EpsilonDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<(IEnumerable<Customer>, int)> GetPagedAsync(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            var query = DbContext.Customers.OrderBy(x => x.ContactName).AsQueryable();

            var total = await query.CountAsync();

            var paged = await query
                .Skip((page.PageIndex - 1) * page.PageSize)
                .Take(page.PageSize)
                .ToListAsync();

            return (paged, total);
        }
    }
}
