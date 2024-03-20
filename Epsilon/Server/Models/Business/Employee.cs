using Epsilon.Server.Models.Interfaces;

namespace Epsilon.Server.Models.Business
{
    public class Employee : ICompanyMember
    {
        public string Name { get; set; }
    }
}
