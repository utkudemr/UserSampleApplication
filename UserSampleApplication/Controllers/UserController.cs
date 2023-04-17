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
        public UserController(ILogger<UserController> logger, ICreateCustomerService createCustomerService)
        {
            _logger = logger;
            _createCustomerService = createCustomerService;
        }

        [HttpPost(Name = "CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateUserRequestDto request)
        {
            var result = await _createCustomerService.CreateCustomerAsync(request);
            return Ok(result);
        }
    }
}