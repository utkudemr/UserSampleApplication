using Microsoft.AspNetCore.Mvc;
using UserSample.Business.Service.Abstracts;
using UserSample.Domain.Service.Models.User;

namespace UserSampleApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private ICreateCustomerService _createCustomerService;
        private readonly IGetCustomerService _getCustomerService;
        public UserController(ILogger<UserController> logger, ICreateCustomerService createCustomerService, IGetCustomerService getCustomerService)
        {
            _logger = logger;
            _createCustomerService = createCustomerService;
            _getCustomerService = getCustomerService;
        }

        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateUserRequestDto request)
        {
            var result = await _createCustomerService.CreateCustomerAsync(request);
            return Ok(result);
        }

        [HttpGet(Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerById([FromQuery] Guid id)
        {
            _logger.LogInformation("GetCustomerById tetiklenmiþtir1. {@request}", new CreateUserRequestDto(tCKNumber:11111111111,name:"utku",surname:"demir",birthDate:DateTime.Now));

            var result = await _getCustomerService.GetUserById(id);
            return Ok(result);
        }
    }
}