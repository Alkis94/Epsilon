using Epsilon.Shared.Models;
using Epsilon.Shared.Models.Interfaces;

namespace Epsilon.Shared.Services
{
    public static class ValidationService
    {
        public static ValidationResult IsValidCustomer(ICustomer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Company Name is mandatory."
                };
            }

            if (string.IsNullOrWhiteSpace(customer.ContactName))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Contact Name is mandatory."
                };
            }

            if (string.IsNullOrWhiteSpace(customer.Phone))
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Phone is mandatory."
                };
            }

            if (customer.CompanyName.Length > 200)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Company Name cannot exceed 200 characters."
                };
            }

            if (customer.ContactName.Length > 200)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Contact Name cannot exceed 200 characters."
                };
            }

            if (customer.Address?.Length > 200)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Address cannot exceed 200 characters."
                };
            }

            if (customer.City?.Length > 100)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "City cannot exceed 100 characters."
                };
            }

            if (customer.Region?.Length > 100)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Region cannot exceed 100 characters."
                };
            }

            if (customer.Country?.Length > 100)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Country cannot exceed 100 characters."
                };
            }

            if (customer.PostalCode?.Length > 50)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Postal Code cannot exceed 50 characters."
                };
            }

            if (customer.Phone?.Length > 50)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = "Phone cannot exceed 50 characters."
                };
            }

            return new ValidationResult
            {
                IsValid = true,
                ErrorMessage = ""
            };
        }
    }
}
