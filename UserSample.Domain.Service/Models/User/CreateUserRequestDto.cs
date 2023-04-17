using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Models.User
{
    public class CreateUserRequestDto
    {
        public CreateUserRequestDto(long tCKNNumber, string name, string surname, DateTime birthDate)
        {
            TCKNNumber = tCKNNumber;
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public long TCKNNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
