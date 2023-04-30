using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserSample.Business.Service.Abstracts;
using UserSample.Business.Service.Features.Abstracts;
using UserSample.Data.Service.EF;
using UserSample.Data.Service.Entities;
using UserSample.Domain.Service.Core;
using UserSample.Domain.Service.Helpers;
using UserSample.Domain.Service.Models.User;

namespace UserSample.Business.Service.Concretes
{
    public class GetCustomerListFilterService : IGetCustomerListFilterService
    {
        private readonly UserSampleContext _context;
        private readonly ILogger<GetCustomerListFilterService> _logger;

        public GetCustomerListFilterService(UserSampleContext context, ILogger<GetCustomerListFilterService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<UserSampleResponse<List<UserResponseDto>>> GetUserByFilter(FilterUserRequestDto request)
        {
            try
            {
                _logger.LogInformation("GetCustomerListFilterService {@Request}", request);

                var tcknNumber=request.TCKNNumber.ToString();
                var query = from u in _context.Users
                            where u.IsActive == true
                            select u;

                if (!string.IsNullOrEmpty(request.Name))
                    query = query.Where(u => u.Name.Contains(request.Name));

                if (!string.IsNullOrEmpty(request.Surname))
                    query = query.Where(u => u.Surname.Contains(request.Surname));
                if (!string.IsNullOrEmpty(tcknNumber))
                    query = query.Where(u => u.TCKNumber.ToString().Contains(tcknNumber));

                var results = query.Select(u => new UserResponseDto
                {
                    Name = u.Name.MaskName(),
                    Surname = u.Surname.MaskName(),
                    TCKNumber = u.TCKNumber.ToString().MaskTcknNumber(),
                    BirthDate = u.BirthDate.ToShortDateString().MaskDate()

                }).ToList();

                _logger.LogInformation("User list filtered retrieved successfully {@Request}", request);
                return new UserSampleResponse<List<UserResponseDto>>(data: results, isSuccess: true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while user retrieving {@Request}", request);
                return new UserSampleResponse<List<UserResponseDto>>(message:$"An error occured while user retrieving message:{ex.Message}", isSuccess: false);
            }
           
        }
    }


}
