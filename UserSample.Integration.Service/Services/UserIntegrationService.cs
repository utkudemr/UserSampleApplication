using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSample.Business.Service.Services.Abstracts;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Integration.Service.Services
{
    public class UserIntegrationService : IUserIntegrationService
    {
        public async Task<bool> UserIsExist(CreateUserRequestDto user)
        {
            try
            {
                var client = new KPSService.KPSPublicSoapClient(KPSService.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
                var response = await client.TCKimlikNoDogrulaAsync(Convert.ToInt64(user.TCKNumber), user.Name, user.Surname, user.BirthDate.Year);
                return response.Body.TCKimlikNoDogrulaResult;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
