using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Models.User
{
    public class UserResponseDto
    {
        public string TCKNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
    }
}
