using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Entities;
using Epsilon.Server.Repositories.Interfaces;
using Epsilon.Server.Services.Interfaces;
using Epsilon.Shared.Services;

namespace Epsilon.Server.Services
{
    public class CustomerService : ICustomerService
    {
        #region Constructor and Fields
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Public Methods
        public async Task<Customer> Get(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException(nameof(id));
            }

            var customer = await _unitOfWork.CustomerRepository.FindAsync(id);

            if (customer == null)
            {
                throw new BusinessException($"Customer with id {id} was not found.");
            }

            return customer;
        }

        public async Task<(IEnumerable<Customer>, int)> GetPagedAsync(Page page)
        {
            if (page == null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            return await _unitOfWork.CustomerRepository.GetPagedAsync(page);
        }

        public async Task Insert(CustomerInsertOrUpdate customerInsert)
        {
            if (customerInsert == null)
            {
                throw new ArgumentNullException(nameof(customerInsert));
            }

            var validationResult = ValidationService.IsValidCustomer(customerInsert);

            if (!validationResult.IsValid)
            {
                throw new BusinessException(validationResult.ErrorMessage);
            }

            var customer = new Customer
            {
                Id = new Guid(),
                ContactName = customerInsert.ContactName!,
                CompanyName = customerInsert.CompanyName!,
                Address = customerInsert.Address,
                City = customerInsert.City,
                Region = customerInsert.Region,
                Country = customerInsert.Country,
                PostalCode = customerInsert.PostalCode,
                Phone = customerInsert.Phone!
            };

            _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(CustomerInsertOrUpdate customerUpdate)
        {
            if (customerUpdate == null)
            {
                throw new ArgumentNullException(nameof(customerUpdate));
            }

            if (customerUpdate.Id == null)
            {
                throw new ArgumentNullException(nameof(customerUpdate.Id));
            }

            var validationResult = ValidationService.IsValidCustomer(customerUpdate);

            if (!validationResult.IsValid)
            {
                throw new BusinessException(validationResult.ErrorMessage);
            }

            var customer = await _unitOfWork.CustomerRepository.FindAsync(customerUpdate.Id);

            if (customer == null)
            {
                throw new BusinessException($"Customer with id {customerUpdate.Id} was not found.", StatusCodes.Status404NotFound);
            }

            customer.ContactName = customerUpdate.ContactName!;
            customer.CompanyName = customerUpdate.CompanyName!;
            customer.Address = customerUpdate.Address;
            customer.City = customerUpdate.City;
            customer.Region = customerUpdate.Region;
            customer.Country = customerUpdate.Country;
            customer.PostalCode = customerUpdate.PostalCode;
            customer.Phone = customerUpdate.Phone!;

            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException(nameof(id));
            }

            var customer = await _unitOfWork.CustomerRepository.FindAsync(id);

            if (customer == null)
            {
                throw new BusinessException($"Customer with id {id} was not found.");
            }

            _unitOfWork.CustomerRepository.Delete(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
