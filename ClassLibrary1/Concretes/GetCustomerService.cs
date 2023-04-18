using AutoMapper;
using UserSample.Business.Service.Abstracts;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Helpers;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Concretes
{
    public class GetCustomerService : IGetCustomerService
    {
        private IMapper _mapper;

        public GetCustomerService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserSampleResponse<UserResponseDto>> GetUserById(Guid id)
        {
            try
            {
                var user = new User() { TCKNumber = 1111111111, Name = "testutku", Surname = "testutku12", BirthDate = DateTime.Now };

                var mappedUser = _mapper.Map<User, UserResponseDto>(user);

                mappedUser.Name = mappedUser.Name.MaskName();
                mappedUser.Surname = mappedUser.Surname.MaskName();
                mappedUser.TCKNumber = mappedUser.TCKNumber.MaskTcknNumber();
                mappedUser.BirthDate = user.BirthDate.ToShortDateString().MaskDate();

                return new UserSampleResponse<UserResponseDto>(data: mappedUser, isSuccess: true);
            }
            catch (Exception ex)
            {
                return new UserSampleResponse<UserResponseDto>(message:$"An error occured while user retrieving message:{ex.Message}", isSuccess: false);
            }
           
        }
    }


}
