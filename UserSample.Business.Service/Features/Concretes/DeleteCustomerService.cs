using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserSample.Business.Service.Features.Abstracts;
using UserSample.Data.Service.EF;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;

namespace UserSample.Business.Service.Features.Concretes
{
    public class DeleteCustomerService : IDeleteCustomerService
    {
        private readonly UserSampleContext _context;

        private readonly ILogger<DeleteCustomerService> _logger;
        public DeleteCustomerService(UserSampleContext context, ILogger<DeleteCustomerService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserSampleResponse<bool>> DeleteUserById(Guid id)
        {
            try
            {
                var user = await GetUser(id);

                user.IsActive = false;
                _context.Update(user);
                _context.SaveChanges();

                return new UserSampleResponse<bool>(data: true, isSuccess: true);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while user deleting id: {id} errorMessage: {ex.Message}", id, ex.Message);
                return new UserSampleResponse<bool>(message: $"An error occured while user retrieving message:{ex.Message}", isSuccess: false);

            }
        }

        private async Task<User> GetUser(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id && a.IsActive!=false) ??
                throw new ArgumentException($"Active User not exist with this guid: {id}");
        }
    }
}
