using AutoMapper;
using Epsilon.Server.Models.Business;
using Epsilon.Server.Services.Interfaces;
using Epsilon.Shared.Models;
using Microsoft.AspNetCore.Mvc;


namespace Epsilon.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.Get(id);
            var dto = _mapper.Map<CustomerDto>(customer);

            return Ok(dto);
        }

        [HttpGet("GetPaged")]
        [ProducesResponseType(typeof(PaginatedResultDto<CustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPagedAsync([FromQuery] Page page)
        {
            page ??= new Page();

            var (customers, total) = await _customerService.GetPagedAsync(page);
            var dtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            var paginatedResult = new PaginatedResultDto<CustomerDto>
            {
                Total = total,
                Data = dtos
            };

            return Ok(paginatedResult);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerInsertOrUpdate>(customerDto);

            if (customer.Id != null && customer.Id != Guid.Empty)
            {
                await _customerService.Update(customer);
            }
            else
            {
               await _customerService.Insert(customer);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.Delete(id);

            return Ok();
        }
    }
}
