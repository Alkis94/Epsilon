using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Interfaces;

namespace Epsilon.Server.Services
{
    public class CompanyService
    {
        public static void PrintMemberName(ICompanyMember member)
        {
            Console.WriteLine(member.Name);
        }

        public static void TestMemberPrint()
        {
            var employee = new Employee { Name = "Alkis" };
            var manager = new Manager { Name = "Maria" };

            PrintMemberName(employee);
            PrintMemberName(manager);
        }
    }
}
