using Microsoft.AspNetCore.Mvc;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Features.Abstracts;
using UserSample.Domain.Service.Models.User;

namespace UserSampleApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICreateCustomerService _createCustomerService;
        private readonly IGetCustomerService _getCustomerService;
        private readonly IDeleteCustomerService _deleteCustomerService;
        private readonly IGetCustomerListFilterService _getCustomerListFilterService;
        
        public UserController(ICreateCustomerService createCustomerService, IGetCustomerService getCustomerService, IDeleteCustomerService deleteCustomerService, IGetCustomerListFilterService getCustomerListFilterService)
        {
            _createCustomerService = createCustomerService;
            _getCustomerService = getCustomerService;
            _deleteCustomerService = deleteCustomerService;
            _getCustomerListFilterService = getCustomerListFilterService;
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateUserRequestDto request)
        {
            var result = await _createCustomerService.CreateCustomerAsync(request);
            return Ok(result);
        }

        [HttpGet("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById([FromQuery] Guid id)
        {
            var result = await _getCustomerService.GetUserById(id);
            return Ok(result);
        }

        [HttpPost("CustomerByFilter")]
        public async Task<IActionResult> GetCustomerByFilter([FromBody] FilterUserRequestDto request)
        {
            var result = await _getCustomerListFilterService.GetUserByFilter(request);
            return Ok(result);
        }

        [HttpDelete("DeleteCustomerById")]
        public async Task<IActionResult> DeleteCustomerById([FromQuery] Guid id)
        {
            var result = await _deleteCustomerService.DeleteUserById(id);
            return Ok(result);
        }
    }
}