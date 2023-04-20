using AutoMapper;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Services.Abstracts;
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

        public CreateCustomerService(IMapper mapper, IUserIntegrationService userIntegrationService)
        {
            _mapper = mapper;
            _userIntegrationService = userIntegrationService;
        }

        public async Task<UserSampleResponse<bool>> CreateCustomerAsync(CreateUserRequestDto user)
        {
            try
            {

                var userRequestValidator = new CreateCustomerRequestValidator();
                var validationResult = userRequestValidator.Validate(user);
                if (!validationResult.IsValid)
                {
                    return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid,message: validationResult.ErrorMessage());
                }

                var response = await _userIntegrationService.UserIsExist(user);
                if (response == true)
                {
                    var mappedUser = _mapper.Map<CreateUserRequestDto, User>(user);
                    mappedUser.CreatedDate = DateTime.Now;
                    return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid);
                }
                return new UserSampleResponse<bool>(data: false, isSuccess: false,message:"KPS Service not approved");

            }
            catch (Exception ex)
            {
                return new UserSampleResponse<bool>(data: false, isSuccess: false,message:$"An error occured error message:{ex.Message}");
            }

            
        }
    }
}
