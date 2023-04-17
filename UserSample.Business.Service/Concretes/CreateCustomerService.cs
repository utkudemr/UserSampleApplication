using UserSample.Business.Service.Abstracts;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Concretes
{
    public class CreateCustomerService : ICreateCustomerService
    {
        public Task<UserSampleResponse<bool>> CreateCustomerAsync(CreateUserRequestDto customer)
        {
            throw new NotImplementedException();
        }
    }
}
