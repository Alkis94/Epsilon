using AutoMapper;
using Epsilon.Server.Models.Business;
using Epsilon.Server.Models.Entities;
using Epsilon.Shared.Models;

namespace Epsilon.Server.Models.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            MapData();
        }

        private void MapData()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, CustomerInsertOrUpdate>();
        }
    }
}
