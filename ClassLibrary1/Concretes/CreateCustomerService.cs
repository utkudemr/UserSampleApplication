using AutoMapper;
using UserSample.Business.Service.Abstracts;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Models.User;
using UserSample.Domain.Service.Validation.FluentValidation;

namespace UserSample.Business.Service.Concretes
{
    public class CreateCustomerService : ICreateCustomerService
    {
        private IMapper _mapper;

        public CreateCustomerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserSampleResponse<bool>> CreateCustomerAsync(CreateUserRequestDto user)
        {
            try
            {
                var userRequestValidator = new CreateCustomerRequestValidator();
                var validationResult = userRequestValidator.Validate(user);
                if (!validationResult.IsValid)
                {
                    var errorMessages = string.Join(',', validationResult.Errors);
                    return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid,message: errorMessages);
                }

                var mappedUser = _mapper.Map<CreateUserRequestDto, User>(user);
                return new UserSampleResponse<bool>(data: false, isSuccess: validationResult.IsValid);
            }
            catch (Exception ex)
            {
                return new UserSampleResponse<bool>(data: false, isSuccess: false,message:$"An error occured error message:{ex.Message}");
            }

            
        }
    }
}
