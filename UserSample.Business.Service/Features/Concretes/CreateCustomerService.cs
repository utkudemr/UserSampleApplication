using AutoMapper;
using Microsoft.Extensions.Logging;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Services.Abstracts;
using UserSample.Data.Service.EF;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Helpers;
using UserSample.Domain.Service.Models.User;
using UserSample.Domain.Service.Validation.FluentValidation;

namespace UserSample.Business.Service.Concretes
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private IMapper _mapper;
        private IUserIntegrationService _userIntegrationService;
        private readonly UserSampleContext _context;
        private readonly ILogger<CreateCustomerService> _logger;

        public CreateCustomerService(IMapper mapper, IUserIntegrationService userIntegrationService, ILogger<CreateCustomerService> logger, UserSampleContext context)
        {
            _mapper = mapper;
            _userIntegrationService = userIntegrationService;
            _logger = logger;
            _context = context;
        }

        public async Task<UserSampleResponse<bool>> CreateCustomerAsync(CreateUserRequestDto user)
        {
            try
            {

                _logger.LogInformation("CreateCustomerAsync request request {user}", user);
                var userRequestValidator = new CreateCustomerRequestValidator();
                var validationResult = userRequestValidator.Validate(user);
                if (!validationResult.IsValid)
                {
                    var errorMessage = validationResult.ErrorMessage();
                    _logger.LogWarning("CreateCustomerAsync request not valid {errorMessage}", errorMessage);
                    return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid,message: errorMessage);
                }

                var response = await _userIntegrationService.UserIsExist(user);
                if (response == true)
                {
                    var mappedUser = _mapper.Map<CreateUserRequestDto, User>(user);
                    mappedUser.IsActive = true;
                    mappedUser.CreatedDate = DateTime.Now;
                     _context.Users.Add(mappedUser);
                    await _context.SaveChangesAsync();
                    return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid);
                }
                _logger.LogWarning("CreateCustomerAsync user is not exist with this TCKN number");
                return new UserSampleResponse<bool>(data: false, isSuccess: false,message:"KPS Service not approved");

            }
            catch (Exception ex)
            {
                _logger.LogError("CAn error occured error message: :{ex.Message}", ex.Message);
                return new UserSampleResponse<bool>(data: false, isSuccess: false,message:$"An error occured error message:{ex.Message}");
            }
        }
    }
}
