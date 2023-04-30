using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Models.User
{
    public class FilterUserRequestDto
    {
        public long? TCKNNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
