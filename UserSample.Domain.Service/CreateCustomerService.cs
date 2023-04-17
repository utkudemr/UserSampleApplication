using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
