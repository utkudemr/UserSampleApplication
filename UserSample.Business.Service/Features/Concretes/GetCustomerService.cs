using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserSample.Business.Service.Abstracts;
using UserSample.Data.Service.EF;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Helpers;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Concretes
{
    public class GetCustomerService : IGetCustomerService
    {
        private readonly IMapper _mapper;
        private readonly UserSampleContext _context;
        private readonly ILogger<GetCustomerService> _logger;

        public GetCustomerService(IMapper mapper, UserSampleContext context, ILogger<GetCustomerService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<UserSampleResponse<UserResponseDto>> GetUserById(Guid id)
        {
            try
            {
                _logger.LogInformation("GetCustomerService request id: {id}", id);
                var user = await GetUser(id);

                var mappedUser = _mapper.Map<User, UserResponseDto>(user);

                mappedUser.Name = mappedUser.Name.MaskName();
                mappedUser.Surname = mappedUser.Surname.MaskName();
                mappedUser.TCKNumber = mappedUser.TCKNumber.MaskTcknNumber();
                mappedUser.BirthDate = user.BirthDate.ToShortDateString().MaskDate();

                _logger.LogInformation("User retrieved successfully id: {id}", id);
                return new UserSampleResponse<UserResponseDto>(data: mappedUser, isSuccess: true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while user retrieving id: {id}",id);
                return new UserSampleResponse<UserResponseDto>(message:$"An error occured while user retrieving message:{ex.Message}", isSuccess: false);
            }
           
        }

        private async Task<User> GetUser(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id) ??
                throw new ArgumentException($"User not exist with this guid: {id}");
        }
    }


}
