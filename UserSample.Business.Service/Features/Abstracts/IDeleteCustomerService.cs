
using UserSample.Domain.Service.Core;

namespace UserSample.Business.Service.Features.Abstracts
{
    public interface IDeleteCustomerService
    {
        Task<UserSampleResponse<bool>> DeleteUserById(Guid id);
    }
}
