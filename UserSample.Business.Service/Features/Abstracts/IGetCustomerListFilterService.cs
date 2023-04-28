using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Features.Abstracts
{
    public interface IGetCustomerListFilterService
    {
        Task<UserSampleResponse<List<UserResponseDto>>> GetUserByFilter(FilterUserRequestDto request);
    }
}
