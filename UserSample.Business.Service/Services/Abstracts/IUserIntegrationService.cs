using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Services.Abstracts
{
    public interface IUserIntegrationService
    {
        Task<bool> UserIsExist(CreateUserRequestDto user);
    }
}
