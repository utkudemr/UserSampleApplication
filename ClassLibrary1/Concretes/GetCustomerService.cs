using AutoMapper;
using UserSample.Business.Service.Abstracts;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
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
            var user = new User(tCKNNumber: 1111111111, name: "test", surname: "test", birthDate: DateTime.Now);

            var mappedUser = _mapper.Map<User,UserResponseDto>(user);

            return new UserSampleResponse<UserResponseDto>(data: mappedUser, isSuccess:true);
        }
    }
}
