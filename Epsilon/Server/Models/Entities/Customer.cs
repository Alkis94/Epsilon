using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Epsilon.Server.Models.Entities
{
    public class Customer
    {
        [Key]
		public Guid Id { get; set; }

		[Required, StringLength(200), NotNull]
		public string CompanyName { get; set; }

		[Required, StringLength(200), NotNull]
		public string ContactName { get; set; }

		[StringLength(200)]
		public string? Address { get; set; }

		[StringLength(100)]
		public string? City { get; set; }

		[StringLength(100)]
		public string? Region { get; set; }

		[StringLength(50)]
		public string? PostalCode { get; set; }

		[StringLength(100)]
		public string? Country { get; set; }

		[Required, StringLength(50), NotNull]
		public string Phone { get; set; }
	}
}
