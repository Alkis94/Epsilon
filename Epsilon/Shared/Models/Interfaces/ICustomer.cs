namespace Epsilon.Shared.Models.Interfaces
{
    public interface ICustomer
    {
        string? CompanyName { get; set; }

        string? ContactName { get; set; }

        string? Address { get; set; }

        string? City { get; set; }

        string? Region { get; set; }

        string? PostalCode { get; set; }

        string? Country { get; set; }

        string? Phone { get; set; }
    }
}
